﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PopForums.Configuration;
using PopForums.Email;
using PopForums.Extensions;
using PopForums.ExternalLogin;
using PopForums.Feeds;
using PopForums.Models;
using PopForums.Mvc.Areas.Forums.Models;
using PopForums.Mvc.Areas.Forums.Services;
using PopForums.ScoringGame;
using PopForums.Services;
using PopForums.Mvc.Areas.Forums.Extensions;

namespace PopForums.Mvc.Areas.Forums.Controllers
{
	[Area("Forums")]
	public class AccountController : Controller
	{
		public AccountController(IUserService userService, IProfileService profileService, INewAccountMailer newAccountMailer, ISettingsManager settingsManager, IPostService postService, ITopicService topicService, IForumService forumService, ILastReadService lastReadService, IClientSettingsMapper clientSettingsMapper, IUserEmailer userEmailer, IImageService imageService, IFeedService feedService, IUserAwardService userAwardService, IExternalUserAssociationManager externalUserAssociationManager, IUserRetrievalShim userRetrievalShim, IAuthenticationSchemeProvider authenticationSchemeProvider)
		{
			_userService = userService;
			_settingsManager = settingsManager;
			_profileService = profileService;
			_newAccountMailer = newAccountMailer;
			_postService = postService;
			_topicService = topicService;
			_forumService = forumService;
			_lastReadService = lastReadService;
			_clientSettingsMapper = clientSettingsMapper;
			_userEmailer = userEmailer;
			_imageService = imageService;
			_feedService = feedService;
			_userAwardService = userAwardService;
			_externalUserAssociationManager = externalUserAssociationManager;
			_userRetrievalShim = userRetrievalShim;
			_authenticationSchemeProvider = authenticationSchemeProvider;
		}

		public static string Name = "Account";
		public static string CoppaDateKey = "CoppaDateKey";
		public static string TosKey = "TosKey";
		public static string ServerTimeZoneKey = "ServerTimeZoneKey";

		private readonly IUserService _userService;
		private readonly ISettingsManager _settingsManager;
		private readonly IProfileService _profileService;
		private readonly INewAccountMailer _newAccountMailer;
		private readonly IPostService _postService;
		private readonly ITopicService _topicService;
		private readonly IForumService _forumService;
		private readonly ILastReadService _lastReadService;
		private readonly IClientSettingsMapper _clientSettingsMapper;
		private readonly IUserEmailer _userEmailer;
		private readonly IImageService _imageService;
		private readonly IFeedService _feedService;
		private readonly IUserAwardService _userAwardService;
		private readonly IExternalUserAssociationManager _externalUserAssociationManager;
		private readonly IUserRetrievalShim _userRetrievalShim;
		private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;

		public ViewResult Create()
		{
			SetupCreateData();
			var signupData = new SignupData
			{
				IsDaylightSaving = true,
				IsSubscribed = true,
				TimeZone = _settingsManager.Current.ServerTimeZone
			};
			return View(signupData);
		}

		private void SetupCreateData()
		{
			ViewData[CoppaDateKey] = SignupData.GetCoppaDate();
			ViewData[TosKey] = _settingsManager.Current.TermsOfService;
			ViewData[ServerTimeZoneKey] = _settingsManager.Current.ServerTimeZone;
		}
		
		[HttpPost]
		public async Task<ViewResult> Create(SignupData signupData)
		{
			var ip = HttpContext.Connection.RemoteIpAddress.ToString();
			ValidateSignupData(signupData, ModelState, ip);
			if (ModelState.IsValid)
			{
				var user = _userService.CreateUser(signupData, ip);
				_profileService.Create(user, signupData);
				// TODO: get rid of FullUrlHelper extension
				var verifyUrl = this.FullUrlHelper("Verify", "Account");
				var result = _newAccountMailer.Send(user, verifyUrl);
				if (result != SmtpStatusCode.Ok)
					ViewData["EmailProblem"] = Resources.EmailProblemAccount + (result?.ToString() ?? "App exception") + ".";
				if (_settingsManager.Current.IsNewUserApproved)
				{
					ViewData["Result"] = Resources.AccountReady;
					_userService.Login(user, ip);
				}
				else
					ViewData["Result"] = Resources.AccountReadyCheckEmail;
				
				
								

				return View("AccountCreated");
			}
			SetupCreateData();
			return View(signupData);
		}

		private void ValidateSignupData(SignupData signupData, ModelStateDictionary modelState, string ip)
		{
			if (!signupData.IsCoppa)
				modelState.AddModelError("IsCoppa", Resources.MustBe13);
			if (!signupData.IsTos)
				modelState.AddModelError("IsTos", Resources.MustAcceptTOS);
			string passwordError;
			var passwordValid = _userService.IsPasswordValid(signupData.Password, out passwordError);
			if (!passwordValid)
				modelState.AddModelError("Password", passwordError);
			if (signupData.Password != signupData.PasswordRetype)
				modelState.AddModelError("PasswordRetype", Resources.RetypeYourPassword);
			if (String.IsNullOrWhiteSpace(signupData.Name))
				modelState.AddModelError("Name", Resources.NameRequired);
			else if (_userService.IsNameInUse(signupData.Name))
				modelState.AddModelError("Name", Resources.NameInUse);
			if (String.IsNullOrWhiteSpace(signupData.Email))
				modelState.AddModelError("Email", Resources.EmailRequired);
			else
				if (!signupData.Email.IsEmailAddress())
				modelState.AddModelError("Email", Resources.ValidEmailAddressRequired);
			else if (signupData.Email != null && _userService.IsEmailInUse(signupData.Email))
				modelState.AddModelError("Email", Resources.EmailInUse);
			if (signupData.Email != null && _userService.IsEmailBanned(signupData.Email))
				modelState.AddModelError("Email", Resources.EmailBanned);
			if (_userService.IsIPBanned(ip))
				modelState.AddModelError("Email", Resources.IPBanned);
		}

		public ViewResult Verify(string id)
		{
			var authKey = Guid.Empty;
			if (!String.IsNullOrWhiteSpace(id) && !Guid.TryParse(id, out authKey))
				return View("VerifyFail");
			if (String.IsNullOrWhiteSpace(id))
				return View();
			var user = _userService.VerifyAuthorizationCode(authKey, HttpContext.Connection.RemoteIpAddress.ToString());
			if (user == null)
				return View("VerifyFail");
			ViewData["Result"] = Resources.AccountVerified;
			_userService.Login(user, HttpContext.Connection.RemoteIpAddress.ToString());
			return View();
		}

		[HttpPost]
		public RedirectToActionResult VerifyCode(string authorizationCode)
		{
			return RedirectToAction("Verify", new { id = authorizationCode });
		}

		public ViewResult RequestCode(string email)
		{
			var user = _userService.GetUserByEmail(email);
			if (user == null)
			{
				ViewData["Result"] = Resources.NoUserFoundWithEmail;
				return View("Verify", new { id = String.Empty });
			}
			var verifyUrl = this.FullUrlHelper("Verify", "Account");
			var result = _newAccountMailer.Send(user, verifyUrl);
			if (result != SmtpStatusCode.Ok)
				ViewData["EmailProblem"] = Resources.EmailProblemAccount + result + ".";
			else
				ViewData["Result"] = Resources.VerificationEmailSent;
			return View("Verify", new { id = String.Empty });
		}

		public ViewResult Forgot()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Forgot(string email)
		{
			var user = _userService.GetUserByEmail(email);
			if (user == null)
			{
				ViewBag.Result = Resources.EmailNotFound;
			}
			else
			{
				ViewBag.Result = Resources.ForgotInstructionsSent;
				var resetLink = this.FullUrlHelper("ResetPassword", "Account");
				_userService.GeneratePasswordResetEmail(user, resetLink);
			}
			return View();
		}

		public ActionResult ResetPassword(string id)
		{
			var authKey = Guid.Empty;
			if (!String.IsNullOrWhiteSpace(id) && !Guid.TryParse(id, out authKey))
				return StatusCode(403);
			var user = _userService.GetUserByAuhtorizationKey(authKey);
			var container = new PasswordResetContainer();
			if (user == null)
				container.IsValidUser = false;
			else
				container.IsValidUser = true;
			return View(container);
		}

		[HttpPost]
		public ActionResult ResetPassword(string id, PasswordResetContainer resetContainer)
		{
			var authKey = Guid.Empty;
			if (!String.IsNullOrWhiteSpace(id) && !Guid.TryParse(id, out authKey))
				return StatusCode(403);
			var user = _userService.GetUserByAuhtorizationKey(authKey);
			resetContainer.IsValidUser = true;
			if (resetContainer.Password != resetContainer.PasswordRetype)
				ModelState.AddModelError("PasswordRetype", Resources.RetypePasswordMustMatch);
			string errorMessage;
			_userService.IsPasswordValid(resetContainer.Password, out errorMessage);
			if (!String.IsNullOrWhiteSpace(errorMessage))
				ModelState.AddModelError("Password", errorMessage);
			if (!ModelState.IsValid)
				return View(resetContainer);
			_userService.ResetPassword(user, resetContainer.Password, HttpContext.Connection.RemoteIpAddress.ToString());
			return RedirectToAction("ResetPasswordSuccess");
		}

		public ActionResult ResetPasswordSuccess()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return RedirectToAction("Login");
			return View();
		}

		public ViewResult EditProfile()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			var profile = _profileService.GetProfileForEdit(user);
			var userEdit = new UserEditProfile(profile);
			return View(userEdit);
		}

		[HttpPost]
		public ViewResult EditProfile(UserEditProfile userEdit)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			_userService.EditUserProfile(user, userEdit);
			ViewBag.Result = Resources.ProfileUpdated;
			return View(userEdit);
		}

		public ViewResult Security()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			var isNewUserApproved = _settingsManager.Current.IsNewUserApproved;
			var userEdit = new UserEditSecurity(user, isNewUserApproved);
			return View(userEdit);
		}

		[HttpPost]
		public ViewResult ChangePassword(UserEditSecurity userEdit)
		{
			string errorMessage;
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			if (!_userService.VerifyPassword(user, userEdit.OldPassword))
				ViewBag.PasswordResult = Resources.OldPasswordIncorrect;
			else if (!userEdit.NewPasswordsMatch())
				ViewBag.PasswordResult = Resources.RetypePasswordMustMatch;
			else if (!_userService.IsPasswordValid(userEdit.NewPassword, out errorMessage))
				ViewBag.PasswordResult = errorMessage;
			else
			{
				_userService.SetPassword(user, userEdit.NewPassword, HttpContext.Connection.RemoteIpAddress.ToString(), user);
				ViewBag.PasswordResult = Resources.NewPasswordSaved;
			}
			return View("Security", new UserEditSecurity { NewEmail = String.Empty, NewEmailRetype = String.Empty, IsNewUserApproved = _settingsManager.Current.IsNewUserApproved });
		}

		[HttpPost]
		public ViewResult ChangeEmail(UserEditSecurity userEdit)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			if (String.IsNullOrWhiteSpace(userEdit.NewEmail) || !userEdit.NewEmail.IsEmailAddress())
				ViewBag.EmailResult = Resources.ValidEmailAddressRequired;
			else if (userEdit.NewEmail != userEdit.NewEmailRetype)
				ViewBag.EmailResult = Resources.EmailsMustMatch;
			else if (_userService.IsEmailInUseByDifferentUser(user, userEdit.NewEmail))
				ViewBag.EmailResult = Resources.EmailInUse;
			else
			{
				_userService.ChangeEmail(user, userEdit.NewEmail, user, HttpContext.Connection.RemoteIpAddress.ToString());
				if (_settingsManager.Current.IsNewUserApproved)
					ViewBag.EmailResult = Resources.EmailChangeSuccess;
				else
				{
					ViewBag.EmailResult = Resources.VerificationEmailSent;
					var verifyUrl = this.FullUrlHelper("Verify", "Account");
					var result = _newAccountMailer.Send(user, verifyUrl);
					if (result != SmtpStatusCode.Ok)
						ViewBag.EmailResult = Resources.EmailProblemAccount + result;
				}
			}
			return View("Security", new UserEditSecurity { NewEmail = String.Empty, NewEmailRetype = String.Empty, IsNewUserApproved = _settingsManager.Current.IsNewUserApproved });
		}

		public ViewResult ManagePhotos()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			var profile = _profileService.GetProfile(user);
			var userEdit = new UserEditPhoto(profile);
			if (profile.ImageID.HasValue)
				userEdit.IsImageApproved = _imageService.IsUserImageApproved(profile.ImageID.Value);
			return View(userEdit);
		}
		
		[HttpPost]
		public ActionResult ManagePhotos(UserEditPhoto userEdit)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			byte[] avatarFile = null;
			if (userEdit.AvatarFile != null)
				avatarFile = userEdit.AvatarFile.OpenReadStream().ToBytes();
			byte[] photoFile = null;
			if (userEdit.PhotoFile != null)
				photoFile = userEdit.PhotoFile.OpenReadStream().ToBytes();
			_userService.EditUserProfileImages(user, userEdit.DeleteAvatar, userEdit.DeleteImage, avatarFile, photoFile);
			return RedirectToAction("ManagePhotos");
		}

		public ViewResult MiniProfile(int id)
		{
			var user = _userService.GetUser(id);
			if (user == null)
				return View("MiniUserNotFound");
			var profile = _profileService.GetProfile(user);
			UserImage userImage = null;
			if (profile.ImageID.HasValue)
				userImage = _imageService.GetUserImage(profile.ImageID.Value);
			var model = new DisplayProfile(user, profile, userImage);
			model.PostCount = _postService.GetPostCount(user);
			var viewingUser = _userRetrievalShim.GetUser(HttpContext);
			if (viewingUser == null)
				model.ShowDetails = false;
			return View(model);
		}

		public ActionResult ViewProfile(int id)
		{
			var user = _userService.GetUser(id);
			if (user == null)
				return NotFound();
			var profile = _profileService.GetProfile(user);
			UserImage userImage = null;
			if (profile.ImageID.HasValue)
				userImage = _imageService.GetUserImage(profile.ImageID.Value);
			var model = new DisplayProfile(user, profile, userImage);
			model.PostCount = _postService.GetPostCount(user);
			model.Feed = _feedService.GetFeed(user);
			model.UserAwards = _userAwardService.GetAwards(user);
			var viewingUser = _userRetrievalShim.GetUser(HttpContext);
			if (viewingUser == null)
				model.ShowDetails = false;
			return View(model);
		}

		public ActionResult Posts(int id, int page = 1)
		{
			var postUser = _userService.GetUser(id);
			if (postUser == null)
				return NotFound();
			var includeDeleted = false;
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user != null && user.IsInRole(PermanentRoles.Moderator))
				includeDeleted = true;
			var titles = _forumService.GetAllForumTitles();
			PagerContext pagerContext;
			var topics = _topicService.GetTopics(user, postUser, includeDeleted, page, out pagerContext);
			var container = new PagedTopicContainer { ForumTitles = titles, PagerContext = pagerContext, Topics = topics };
			_lastReadService.GetTopicReadStatus(user, container);
			ViewBag.PostUserName = postUser.Name;
			return View(container);
		}

		public JsonResult ClientSettings()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return Json(_clientSettingsMapper.GetDefault());
			var profile = _profileService.GetProfile(user);
			return Json(_clientSettingsMapper.GetClientSettings(profile));
		}

		public ViewResult Login()
		{
			string link;
			if (Request == null || string.IsNullOrWhiteSpace(Request.Headers["Referer"]))
				link = Url.Action("Index", HomeController.Name);
			else
			{
				link = Request.Headers["Referer"];
				if (!link.Contains(Request.Host.Value))
					link = Url.Action("Index", HomeController.Name);
			}
			ViewBag.Referrer = link;

			var externalLoginList = GetExternalLoginList();

			return View(externalLoginList);
		}

		private List<AuthenticationScheme> GetExternalLoginList()
		{
			var schemes = _authenticationSchemeProvider.GetAllSchemesAsync().Result
				.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName)).ToList();
			return schemes;
		}

		public ActionResult EmailUser(int id)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return StatusCode(403);
			var toUser = _userService.GetUser(id);
			if (toUser == null)
				return NotFound();
			if (!_userEmailer.IsUserEmailable(toUser))
				return StatusCode(403);
			ViewBag.IP = HttpContext.Connection.RemoteIpAddress.ToString();
			return View(toUser);
		}

		[HttpPost]
		public ActionResult EmailUser(int id, string subject, string text)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return StatusCode(403);
			var toUser = _userService.GetUser(id);
			if (toUser == null)
				return NotFound();
			if (!_userEmailer.IsUserEmailable(toUser))
				return StatusCode(403);
			if (String.IsNullOrWhiteSpace(subject) || String.IsNullOrWhiteSpace(text))
			{
				ViewBag.EmailResult = Resources.PMCreateWarnings;
				ViewBag.IP = HttpContext.Connection.RemoteIpAddress.ToString();
				return View(toUser);
			}
			_userEmailer.ComposeAndQueue(toUser, user, HttpContext.Connection.RemoteIpAddress.ToString(), subject, text);
			return View("EmailSent");
		}

		public ViewResult Unsubscribe(int id, string key)
		{
			var user = _userService.GetUser(id);
			if (user == null || !_profileService.Unsubscribe(user, key))
				return View("UnsubscribeFailure");
			return View();
		}

		public ViewResult ExternalLogins()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			var externalAssociations = _externalUserAssociationManager.GetExternalUserAssociations(user);
			ViewBag.Referrer = Url.Action("ExternalLogins");
			return View(externalAssociations);
		}

		public ActionResult RemoveExternalLogin(int id)
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			if (user == null)
				return View("EditAccountNoUser");
			_externalUserAssociationManager.RemoveAssociation(user, id, HttpContext.Connection.RemoteIpAddress.ToString());
			return RedirectToAction("ExternalLogins");
		}
	}
}
