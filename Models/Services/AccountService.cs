using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Context.Account;
using Models.Contracts;
using Models.Extensions;
using Models.ViewModels.Account;
using Models.ViewModels.CategoriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using WebCommon.Extensions;
using WebCommon.Models;
using WebCommon.Services;

namespace Models.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IUserContext userContext;
        private readonly INomenclatureService nomService;

        public AccountService(MainContext _db, IUserContext _userContext, INomenclatureService _nomService)
        {
            db = _db;
            userContext = _userContext;
            nomService = _nomService;
        }

        public bool AreUserCredentialsValid(string username, string password)
        {
            var user = Users_GetByUserName(username);
            if (user != null)
            {
                if (!user.IsActive || !user.IsApproved || !user.IsMailConfirmed)
                {
                    return false;
                }
                return CheckPassword(password, user);
            }
            return false;
        }

        public IEnumerable<SelectListItem> Combo_UserTypes()
        {
            int[] userTypes = new int[] { GlobalConstants.UserTypes.Internal, GlobalConstants.UserTypes.Public };
            return db.UsersTypes.Where(x => userTypes.Contains(x.Id))
                        .OrderBy(x => x.Name)
                        .ToSelectList(x => x.Id, x => x.Name);
        }

        public void GeneratePasswordHash()
        {
            var users = db.Users;
            foreach (var item in users)
            {
                var passwordHasher = new PasswordHasher<Users>();
                item.Password = passwordHasher.HashPassword(item, item.Password);
                item.Comment = "hashed";
                db.Users.Update(item);

            }
            db.SaveChanges();
        }

        public ClaimsPrincipal GeneratePrincipalByUsername(string username)
        {
            var user = Users_GetByUserName(username);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, (user.FullName ?? user.UserName)));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var userRole in user.UsersInRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Alias));
            }
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
        }

        public Users Users_GetByUserName(string userName)
        {
            return db.Users
                .Where(x => x.UserName == userName)
                .Include(x => x.UsersInRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();
        }

        public UserEditVM Users_GetById(int id)
        {
            return db.Users
                    .Include(x => x.UsersType)
                 .Where(x => x.Id == id)
                 .Select(x => new UserEditVM
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Organization = x.Organization,
                     Address = x.Address,
                     Phone = x.Phone,
                     Email = x.Email,
                     UserName = x.UserName,
                     IsMailConfirmed = x.IsMailConfirmed,
                     IsActive = x.IsActive,
                     IsApproved = x.IsApproved,
                     UserType = x.UsersType.Name
                 }).FirstOrDefault();
        }

        public bool Groups_SaveData(Groups model)
        {
            if (model.Id > 0)
            {
                var saved = db.Groups.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                model.CreatedByUserId = saved.CreatedByUserId;
                model.DateCreated = saved.DateCreated;
                model.ModifiedByUserId = userContext.UserId;
                model.DateModified = DateTime.Now;
                db.Groups.Update(model);
                db.SaveChanges();
            }
            else
            {
                model.CreatedByUserId = userContext.UserId;
                model.DateCreated = DateTime.Now;
                model.ModifiedByUserId = userContext.UserId;
                model.DateModified = DateTime.Now;
                db.Groups.Add(model);
                db.SaveChanges();
            }
            return true;
        }

        public IQueryable<Groups> Groups_Select()
        {
            return All<Groups>().OrderBy(x => x.Name).AsQueryable();
        }

        public bool GroupUsers_SaveData(GroupUserVM model)
        {
            if (model.Id > 0)
            {
                var saved = Find<Users>(model.Id);
                saved.CategoryId = model.CategoryId;
                saved.Organization = model.Organization;
                saved.InstitutionTypeId = model.InstitutionTypeId;
                saved.Address = model.Address;
                saved.Phone = model.Phone;
                saved.Email = model.Email;
                saved.IsActive = model.IsActive;
                saved.DateModified = DateTime.Now;
                saved.ModifiedByUserId = userContext.UserId;
                db.Users.Update(saved);
                db.SaveChanges();
            }
            else
            {
                var user = new Users()
                {
                    UserTypeId = GlobalConstants.UserTypes.Group,
                    CategoryId = model.CategoryId,
                    FullName = model.Organization,
                    Organization = model.Organization,
                    InstitutionTypeId = model.InstitutionTypeId,
                    Address = model.Address,
                    Email = model.Email,
                    Phone = model.Phone,
                    IsActive = true,
                    IsMailConfirmed = true,
                    CreatedByUserId = userContext.UserId,
                    DateCreated = DateTime.Now,
                    ModifiedByUserId = userContext.UserId,
                    DateModified = DateTime.Now
                };

                db.Users.Add(user);
                db.SaveChanges();
                model.Id = user.Id;
            }
            return true;
        }

        public IQueryable<GroupUserVM> GroupUsers_Select(int? id = null)
        {
            Func<Users, bool> MyGroupsOnly = x => true;
            if (!userContext.IsInRole(GlobalConstants.Roles.Admin))
            {
                var myGroups = All<UsersInGroups>()
                                    .Where(x => x.UserId == userContext.UserId)
                                    .Select(x => x.GroupUserId)
                                    .ToArray() ?? new int[0];
                MyGroupsOnly = x => myGroups.Contains(x.Id);
            }



            return All<Users>()
                        .Where(x => x.UserTypeId == GlobalConstants.UserTypes.Group)
                        .Where(x => x.Id == (id ?? x.Id))
                        .Where(MyGroupsOnly)
                        .Select(x => new GroupUserVM
                        {
                            Id = x.Id,
                            CategoryId = x.CategoryId ?? 0,
                            CategoryName = (x.Category != null) ? x.Category.CategoryName : "",
                            CategoryParent = (x.Category != null) ? x.Category.ParentId : 0,
                            Organization = x.Organization,
                            InstitutionTypeId = x.InstitutionTypeId,
                            Address = x.Address,
                            Phone = x.Phone,
                            Email = x.Email,
                            IsActive = x.IsActive
                        })
                        .OrderBy(x => x.Organization)
                        .AsQueryable();
        }

        public IQueryable<UserVM> Users_Select(string fullName, string userName, int? userType, bool? isApproved)
        {

            int[] userTypes = new int[] { GlobalConstants.UserTypes.Internal, GlobalConstants.UserTypes.Public };

            return db.Users
                    .Include(x => x.UsersType)
                    .Where(x => (x.FullName.Contains(fullName ?? x.FullName)) && (x.UserName.Contains(userName ?? x.UserName)))
                    .Where(x => x.IsApproved == (isApproved ?? x.IsApproved))
                    .Where(x => x.UserTypeId == (userType ?? x.UserTypeId) && userTypes.Contains(x.UserTypeId))
                    .Select(x => new UserVM
                    {
                        UserId = x.Id,
                        UserName = x.UserName,
                        FullName = x.FullName,
                        Email = x.Email,
                        IsApproved = x.IsApproved,
                        IsActive = x.IsActive,
                        IsConfirmed = x.IsMailConfirmed,
                        UserType = x.UsersType.Name
                    }).AsQueryable();
        }

        public bool Users_Update(UserEditVM model)
        {
            var saved = db.Users.Find(model.Id);
            if (saved != null)
            {
                saved.Email = model.Email;
                saved.FirstName = model.FirstName;
                saved.LastName = model.LastName;
                saved.FullName = model.GetFullName;
                saved.Organization = model.Organization;
                saved.Address = model.Address;
                saved.Phone = model.Phone;
                saved.IsApproved = model.IsApproved;
                saved.IsActive = model.IsActive;
                saved.IsMailConfirmed = model.IsMailConfirmed;
                saved.ModifiedByUserId = userContext.UserId;
                saved.DateModified = DateTime.Now;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UserRoles_Save(UserRolesVM model)
        {
            Func<UsersInRoles, bool> bezAdmin = x => true;
            if (!userContext.IsInRole(GlobalConstants.Roles.Admin))
            {
                bezAdmin = x => x.Role.Alias != GlobalConstants.Roles.Admin;
            }
            var forDelete = All<UsersInRoles>()
                                .Include(x => x.Role)
                                .Where(x => x.UserId == model.UserId)
                                .Where(bezAdmin);
            db.UsersInRoles.RemoveRange(forDelete);
            bool hasChecked = false;
            foreach (var item in model.Roles.Where(x => x.Selected))
            {
                hasChecked = true;
                db.UsersInRoles.Add(new UsersInRoles()
                {
                    UserId = model.UserId,
                    RoleId = int.Parse(item.Value)
                });
            }

            if (hasChecked)
            {
                db.SaveChanges();
            }
            return hasChecked;
        }

        public UserRolesVM UserRoles_Select(int userId)
        {
            Func<Roles, bool> ExcludeAdmin = x => true;
            if (!userContext.IsInRole(GlobalConstants.Roles.Admin))
            {
                ExcludeAdmin = x => x.Alias != GlobalConstants.Roles.Admin;
            }
            var _roles = db.Roles
                            .Where(ExcludeAdmin)
                            .OrderBy(x => x.Alias)
                            .ToList()
                            .Select(x => new TextValueVM
                            {
                                Text = x.Name,
                                Value = x.Id.ToString(),
                                Alias = x.Alias
                            })
                            .ToList();


            var saved = db.UsersInRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();
            foreach (var item in _roles)
            {
                item.Selected = saved.Any(x => x.ToString() == item.Value);
            }

            return new UserRolesVM()
            {
                UserId = userId,
                Roles = _roles
            };
        }

        public string Users_CheckRegistration(RegisterInternalUserVM model)
        {
            if (db.Users.Any(x => x.UserName == model.UserName.Trim()))
            {
                return "Потребителското име вече е заето.";
            }
            if (db.Users.Any(x => x.Email == model.Email.Trim()))
            {
                return "Вече съществува регистрация с въведената електронна поща.";
            }

            return string.Empty;
        }

        public bool Users_ConfirmAndApproveMail(Users model)
        {
            model.IsMailConfirmed = true;
            model.IsApproved = true;
            model.DateModified = DateTime.Now;
            db.Users.Update(model);
            db.SaveChanges();
            return true;
        }

        public Users Users_GetByVerificationCode(string code)
        {
            var passphrase = code.Substring(0, 10);
            var username = code.Substring(10).Decrypt(passphrase);

            return Users_GetByUserName(username);
        }

        public string Users_GenerateVerificationCode(string username)
        {
            var passphrase = Guid.NewGuid()
                  .ToString()
                  .Substring(0, 10);
            var code = username.Encrypt(passphrase);

            return String.Concat(passphrase, code);
        }

        public ClaimsPrincipal Users_LoginRegisterExternalAuth(ClaimsPrincipal extPrincipal)
        {
            var email = extPrincipal.Claims.GetValue(ClaimTypes.Email);
            var providerName = ((ClaimsIdentity)extPrincipal.Identity).AuthenticationType;
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
            var savedUser = db.Users.Where(x => x.Email == email).FirstOrDefault();
            if (savedUser != null)
            {
                return GeneratePrincipalByUsername(savedUser.UserName);
            }

            RegisterPublicUserVM newUser = new RegisterPublicUserVM()
            {
                Email = email,
                ExternalProvider = providerName
            };
            switch (providerName)
            {
                case GlobalConstants.ExternalProviders.Facebook:
                    {
                        newUser.FirstName = extPrincipal.Claims.GetValue(ClaimTypes.GivenName);
                        newUser.LastName = extPrincipal.Claims.GetValue(ClaimTypes.Surname);
                        newUser.UserName = extPrincipal.Claims.GetValue(ClaimTypes.NameIdentifier);
                    }
                    break;
                case GlobalConstants.ExternalProviders.Twitter:
                    {
                        newUser.FirstName = extPrincipal.Claims.GetValue(ClaimTypes.Name);
                        //newUser.LastName = extPrincipal.Claims.GetValue(ClaimTypes.Surname);
                        newUser.UserName = extPrincipal.Claims.GetValue(ClaimTypes.NameIdentifier);
                    }
                    break;
            }
            if (this.Users_RegisterPublic(newUser, true))
            {
                return GeneratePrincipalByUsername(newUser.UserName);
            }
            return null;
        }

        public bool Users_RegisterInternal(RegisterInternalUserVM model)
        {
            var passwordHasher = new PasswordHasher<Users>();

            var user = new Users()
            {
                UserTypeId = GlobalConstants.UserTypes.Internal,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FullName,
                Organization = model.Organization,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                IsApproved = true,
                IsActive = true,
                IsMailConfirmed = true,
                CreatedByUserId = userContext.UserId,
                DateCreated = DateTime.Now,
                ModifiedByUserId = userContext.UserId,
                DateModified = DateTime.Now
            };
            user.Password = passwordHasher.HashPassword(user, model.UserName);
            if (model.GroupId > 0)
            {
                user.UsersInGroups.Add(new UsersInGroups() { GroupUserId = model.GroupId.Value });
            }
            db.Users.Add(user);
            db.SaveChanges();
            model.Id = user.Id;
            return true;
        }

        public bool Users_RegisterPublic(RegisterPublicUserVM model, bool autoConfirmMain = false)
        {
            var passwordHasher = new PasswordHasher<Users>();

            var user = new Users()
            {
                UserTypeId = GlobalConstants.UserTypes.Public,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FullName,
                Organization = model.Organization,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                IsApproved = autoConfirmMain,
                IsActive = true,
                IsMailConfirmed = autoConfirmMain,
                CreatedByUserId = 0,
                DateCreated = DateTime.Now,
                ModifiedByUserId = 0,
                DateModified = DateTime.Now
            };
            if (!string.IsNullOrEmpty(model.ExternalProvider))
            {
                user.Password = model.ExternalProvider;
            }
            else
            {
                user.Password = passwordHasher.HashPassword(user, model.Password);
            }
            db.Users.Add(user);
            db.SaveChanges();
            model.Id = user.Id;
            return true;
        }
        public vOldUser ValidateUser_Old(string username, string password)
        {
            return db.vOldUsers.FirstOrDefault(x => x.UserName == username && x.Password == password && x.IsApproved);
        }


        private bool CheckPassword(string password, Users user)
        {
            var passwordHasher = new PasswordHasher<Users>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result > 0;
        }

        public IQueryable<UserInGroupVM> UserInGroup_Select(int? groupId, int? userId)
        {
            return All<UsersInGroups>()
                     .Include(x => x.User)
                     .Include(x => x.Group)
                     .Where(x => x.GroupUserId == (groupId ?? x.GroupUserId))
                     .Where(x => x.UserId == (userId ?? x.UserId))
                     .Select(x => new UserInGroupVM
                     {
                         GroupUserId = x.Group.Id,
                         GroupName = x.Group.FullName,
                         UserId = x.User.Id,
                         UserFullName = x.User.FullName,
                         UserEmail = x.User.Email
                     }).AsQueryable();
        }

        public bool UserInGroup_Add(int groupId, int userId)
        {
            if (db.UsersInGroups.Any(x => x.UserId == userId && x.GroupUserId == groupId))
            {
                return false;
            }
            db.UsersInGroups.Add(new UsersInGroups()
            {
                UserId = userId,
                GroupUserId = groupId
            });
            db.SaveChanges();
            return true;
        }

        public bool UserInGroup_Remove(int groupId, int userId)
        {
            var model = db.UsersInGroups.FirstOrDefault(x => x.UserId == userId && x.GroupUserId == groupId);
            if (model == null)
            {
                return false;
            }

            db.UsersInGroups.Remove(model);
            db.SaveChanges();
            return true;

        }

        public bool Users_UpdateProfile(UserEditVM model)
        {
            var saved = db.Users.Find(model.Id);
            if (saved != null)
            {
                saved.FirstName = model.FirstName;
                saved.LastName = model.LastName;
                saved.FullName = model.GetFullName;
                saved.ModifiedByUserId = userContext.UserId;
                saved.DateModified = DateTime.Now;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public IQueryable<UserInCategoryVM> UserInCategories_Select(int? userId, int? categoryId)
        {
            return All<UsersInCategories>()
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Where(x => x.UserId == (userId ?? x.UserId) && x.CategoryId == (categoryId ?? x.CategoryId))
                    .Select(x => new UserInCategoryVM
                    {
                        UserId = x.UserId,
                        UserFullName = x.User.FullName,
                        CategoryId = x.CategoryId,
                        CategoryMasterId = x.Category.ParentId,
                        CategoryName = x.Category.CategoryName
                    }).AsQueryable();
        }

        public UserInCategoriesVM UserInCategoriesVM_Select(int userId)
        {
            var model = new UserInCategoriesVM();

            var catMasters = nomService.ComboCategories(0).ToSelectList();

            var userData = this.UserInCategories_Select(userContext.UserId, null);

            foreach (var catMaster in catMasters)
            {
                ParentCategoryViewModel pcvm = new ParentCategoryViewModel();
                pcvm.Id = Convert.ToInt32(catMaster.Value);
                pcvm.CategoryName = catMaster.Text;

                var allCategories = All<Category>()
                    .Where(x => x.ParentId == pcvm.Id && x.IsActive && x.IsApproved && !x.IsDeleted && x.LanguageId == GlobalConstants.LangBG)
                    .AsQueryable();

                foreach (var item in allCategories)
                {
                    CheckBoxListItem t = new CheckBoxListItem
                    {
                        ID = item.Id,
                        ParentCategoryID = pcvm.Id,
                        IsChecked = userData.FirstOrDefault(x => x.CategoryId == item.Id) != null,
                        Display = item.CategoryName
                    };

                    pcvm.Categories.Add(t);
                }

                model.ParentCategories.Add(pcvm);
            }

            return model;
        }

        public bool UserInCategories_SaveAll(int userId, UserInCategoriesVM userInCategories)
        {
            bool result = true;
            foreach (var parentCategory in userInCategories.ParentCategories)
            {
                foreach (var category in parentCategory.Categories)
                {
                    if (category.IsChecked)
                    {
                        if (!this.UserInCategories_Add(userId, category.ID))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        this.UserInCategories_Remove(userId, category.ID);
                    }
                }
            }

            return result;
        }

        public bool UserInCategories_Add(int userId, int categoryId)
        {
            if (All<UsersInCategories>().FirstOrDefault(x => x.UserId == userId && x.CategoryId == categoryId) == null)
            {
                All<UsersInCategories>().Add(new UsersInCategories() { UserId = userId, CategoryId = categoryId });
                db.SaveChanges();
            }

            return true;
        }

        public bool UserInCategories_Remove(int userId, int categoryId)
        {
            if (All<UsersInCategories>().FirstOrDefault(x => x.UserId == userId && x.CategoryId == categoryId) != null)
            {
                DeleteRange<UsersInCategories>(x => x.UserId == userId && x.CategoryId == categoryId);
                db.SaveChanges();
            }

            return true;
        }

        public IQueryable<UserInTargetGroupVM> UserInTargetGroups_Select(int? userId, int? targetGroupId)
        {
            return All<UsersInTargetGroups>()
                    .Include(x => x.User)
                    .Include(x => x.TargetGroup)
                    .Where(x => x.UserId == (userId ?? x.UserId) && x.TargetGroupId == (targetGroupId ?? x.TargetGroupId))
                    .Select(x => new UserInTargetGroupVM
                    {
                        UserId = x.UserId,
                        UserFullName = x.User.FullName,
                        TargetGroupId = x.TargetGroupId,
                        TargetGroupName = x.TargetGroup.Name
                    }).AsQueryable();
        }

        public bool UserInTargetGroups_Add(int userId, int targetGroupId)
        {
            All<UsersInTargetGroups>().Add(new UsersInTargetGroups() { UserId = userId, TargetGroupId = targetGroupId });
            db.SaveChanges();
            return true;
        }

        public bool UserInTargetGroups_Remove(int userId, int targetGroupId)
        {
            DeleteRange<UsersInTargetGroups>(x => x.UserId == userId && x.TargetGroupId == targetGroupId);
            db.SaveChanges();
            return true;
        }

        public bool Users_ChangePassword(ChangePasswordViewModel model)
        {
            var result = false;
            var passwordHasher = new PasswordHasher<Users>();

            try
            {
                var user = Users_GetByVerificationCode(model.Code);

                user.Password = passwordHasher.HashPassword(user, model.Password);

                All<Users>().Update(user);
                db.SaveChanges();

                result = true;
            }
            catch (Exception)
            {

            }

            return result;
        }

        public IQueryable<UserToNotificateVM> Users_SelectForNotification(int? userId, int? categoryId, int? targetGroupId, int? groupUserId)
        {
            Expression<Func<Users, bool>> catExpr = x => false;
            if (categoryId > 0)
            {
                catExpr = x => x.UsersInCategories.Any(g => g.CategoryId == categoryId);
            }

            Expression<Func<Users, bool>> targetGroupExpr = x => false;
            if (targetGroupId > 0)
            {
                targetGroupExpr = x => x.UsersInTargetGroups.Any(g => g.TargetGroupId == targetGroupId);
            }

            Expression<Func<Users, bool>> groupExpr = x => false;
            if (groupUserId > 0)
            {
                groupExpr = x => x.UsersInGroups.Any(g => g.GroupUserId == groupUserId);
            }

            var userSelect = All<Users>()
                        .Include(x => x.UsersInGroups)
                        .Include(x => x.UsersInCategories)
                        .Include(x => x.UsersInTargetGroups)
                        .Where(x => x.IsActive && x.IsApproved && x.IsMailConfirmed);

            if (userId > 0)
            {
                return userSelect.Where(x => x.Id == userId).Select(x => new UserToNotificateVM
                {
                    UserId = x.Id,
                    Email = x.Email
                }).AsQueryable();
            }

            return userSelect.Where(catExpr)
                 .Union(userSelect.Where(targetGroupExpr))
                 .Union(userSelect.Where(groupExpr))
                 .Select(x => new UserToNotificateVM
                 {
                     UserId = x.Id,
                     Email = x.Email
                 })
                 .Distinct()
                 .AsQueryable();
        }
    }
}
