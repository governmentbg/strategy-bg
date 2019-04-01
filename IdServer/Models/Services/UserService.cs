
using IdentityServer4.EntityFramework.DbContexts;
using IdServer.Extensions;
using IdServer.Models.Contracts;
using IdServer.Models.Entities;
using IdServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdServer.Models.Services
{
    public class UserService : IUserService
    {
        IdServerContext _context;
        ConfigurationDbContext confDb;

        public UserService(
            IdServerContext context,
            ConfigurationDbContext _confDb
            )
        {
            _context = context;
            confDb = _confDb;
        }

        public bool AreUserCredentialsValid(string username, string password, string clientId)
        {
            // get the user
            var user = GetUserByUsername(username);
            if (user == null || !user.IsActive || !user.IsMailConfirmed)
            {
                return false;
            }
            //password = "!23456";
            //var passCode = GetPasswordChangeCode(username);
            //ChangePassword(new ChangePasswordViewModel()
            //{
            //    Code = passCode,
            //    Password = password,
            //    PasswordAgain = password
            //});

            DateTime today = DateTime.Today;
            bool challengeResult = CheckPassword(password, user);


            return (challengeResult);
        }

        private bool CheckPassword(string password, User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result > 0;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.IsMailConfirmed && u.IsActive);
        }

        public User GetUserByProvider(string loginProvider, string providerKey)
        {
            return _context.Users
                .FirstOrDefault(u =>
                    u.Logins.Any(l => l.LoginProvider == loginProvider && l.ProviderKey == providerKey));
        }

        public User GetUserById(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<Claim> GetClaimsByUserId(string userId, string clientId)
        {
            // get user with claims
            var user = _context.Users
                .Include(u => u.Claims)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return new List<Claim>();
            }

            var roles = GetRolesByUserId(userId, clientId);

            var claims = user.Claims
                .Where(c => c.ClientId == null || c.ClientId == clientId)
                .ToList();

            foreach (var role in roles)
            {
                claims.Add(new Claim()
                {
                    ClaimType = "role",
                    ClaimValue = role,
                    ClientId = clientId,
                    UserId = userId
                });
            }

            claims.AddRange(new List<Claim>()
            {
                new Claim()
                {
                    ClaimType = "given_name",
                    ClaimValue = user.GivenName,
                    ClientId = clientId,
                    UserId = userId
                },
                new Claim()
                {
                    ClaimType = "family_name",
                    ClaimValue = user.FamilyName,
                    ClientId = clientId,
                    UserId = userId
                },
                new Claim()
                {
                    ClaimType = "full_name",
                    ClaimValue = user.FullName,
                    ClientId = clientId,
                    UserId = userId
                },
                new Claim()
                {
                    ClaimType = "email",
                    ClaimValue = user.Email,
                    ClientId = clientId,
                    UserId = userId
                }
            });


            return claims;
        }

        public IEnumerable<UserLogin> GetUserLoginsByUserId(string userId)
        {
            var user = _context.Users.Include(u => u.Logins).FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return new List<UserLogin>();
            }
            return user.Logins.ToList();
        }

        public bool IsUserActive(string userId)
        {
            var user = GetUserById(userId);
            return user.IsActive;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void AddUserLogin(string userId, string loginProvider, string providerKey)
        {
            var user = GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User with given subjectId not found.", userId);
            }

            user.Logins.Add(new UserLogin()
            {
                UserId = userId,
                LoginProvider = loginProvider,
                ProviderKey = providerKey
            });
        }

        public void AddClaim(string userId, string claimType, string claimValue)
        {
            var user = GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User with given subjectId not found.", userId);
            }

            user.Claims.Add(new Claim(claimType, claimValue));
        }

        public bool IsInRole(string userId, string clientId, string role)
        {
            return _context.Users
                .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                .Where(u => u.Id == userId)
                .Where(u => u.UsersRoles.Any(ur => ur.Role.ClientId == clientId))
                .Any(u => u.UsersRoles.Any(r => r.Role.Name == role));
        }

        public IEnumerable<string> GetRolesByUserId(string userId, string clientId)
        {
            return _context.Users
                .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                .Where(u => u.Id == userId)
                .SelectMany(u => u.UsersRoles.Select(r => r.Role))
                .Where(r => r.ClientId == clientId)
                .Select(u => u.Name);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public User FindByExternalProvider(string provider, string providerUserId)
        {
            User user = null;

            switch (provider)
            {
                case Microsoft.AspNetCore.Authentication.Facebook.FacebookDefaults.AuthenticationScheme:
                    return _context.Users.Include(x => x.Logins).Where(x => x.Logins.Any(l => l.LoginProvider == provider && l.ProviderKey == providerUserId)).FirstOrDefault();
                //case StampIT.Authentication.Id.StampITIdDefaults.AuthenticationScheme:
                //    user = GetUserByEmail(providerUserId);
                //    break;
                default:
                    break;
            }

            return user;
        }

        public IQueryable<UserVM> GetUsers(string search)
        {
            return _context.Users.Where(x => x.FullName.Contains(search ?? x.FullName))
                .Select(x => new UserVM
                {
                    UserId = x.Id,
                    FullName = x.FullName,
                    Username = x.Username
                })
                .AsQueryable();
        }

        public UserRolesVM LoadUserRoles(string subjectId)
        {
            UserRolesVM model = new UserRolesVM();
            var user = GetUserById(subjectId);
            model.UserId = subjectId;
            model.FullName = user.FullName;
            var clientsList = confDb.Clients

                .OrderBy(x => x.ClientName)
                .ToList();


            foreach (var client in clientsList)
            {
                var savedRoles = GetRolesByUserId(subjectId, client.ClientId).ToList();

                ClientRolesVM newClient = new ClientRolesVM()
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName
                };
                newClient.Roles = _context.Roles.Where(x => x.ClientId == client.ClientId).ToList().Select(x => new CheckItemVM
                {
                    Checked = savedRoles.Any(r => r == x.Name),
                    Text = x.DisplayName,
                    Value = x.Id
                }).ToList();
                if (newClient.Roles.Count() > 0)
                {
                    model.ClientRoles.Add(newClient);
                }
            }

            return model;
        }

        public bool SaveUserRoles(UserRolesVM model)
        {
            try
            {
                var savedUserRoles = _context.UsersRoles
                                        .Include(x => x.Role)
                                        .Where(x => x.UserId == model.UserId).ToList();

                //Премахване на отнетите роли
                bool isChanged = false;
                foreach (var item in savedUserRoles)
                {
                    if (!model.ClientRoles.Any(cr => cr.Roles.Any(r => r.Value == item.RoleId && r.Checked)))
                    {
                        _context.UsersRoles.Remove(item);
                        isChanged = true;
                    }
                }

                foreach (var clientRoles in model.ClientRoles)
                {
                    foreach (var role in clientRoles.Roles)
                    {
                        if (role.Checked)
                        {
                            if (!savedUserRoles.Any(x => x.RoleId == role.Value))
                            {
                                _context.UsersRoles.Add(new UserRole()
                                {
                                    UserId = model.UserId,
                                    RoleId = role.Value
                                });
                                isChanged = true;
                            }
                        }
                    }
                }

                if (isChanged)
                {
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserEditVM GetUserEditVMBySubjectId(string subjectId)
        {
            return _context.Users.Where(x => x.Id == subjectId)
                .Select(x => new UserEditVM
                {
                    Id = x.Id,
                    Email = x.Email,
                    FamilyName = x.FamilyName,
                    GivenName = x.GivenName,
                    IsActive = x.IsActive,
                    MiddleName = x.MiddleName,
                    IsMailConfirmed = x.IsMailConfirmed
                })
                .FirstOrDefault();
        }

        public bool SaveUserEdit(UserEditVM model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Id))
                {
                    //Редакция
                    var user = _context.Find<User>(model.Id);
                    user.GivenName = model.GivenName;
                    user.MiddleName = model.MiddleName;
                    user.FamilyName = model.FamilyName;
                    user.IsActive = model.IsActive;
                    user.IsMailConfirmed = model.IsMailConfirmed;

                    user.FullName = model.GetFullName;

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                else
                {
                    //Добавяне
                    User user = new User()
                    {
                        Username = model.Email,
                        Email = model.Email,
                        GivenName = model.GivenName,
                        MiddleName = model.MiddleName,
                        FamilyName = model.FamilyName,
                        FullName = model.GetFullName,
                        IsActive = model.IsActive,
                        MustChangePassword = true,
                        IsMailConfirmed = true
                    };
                    user.Password = user.Email;
                    var passwordHasher = new PasswordHasher<User>();
                    user.Password = passwordHasher.HashPassword(user, user.Password);

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    model.Id = user.Id;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegisterUser(RegisterViewModel model)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = false;

            try
            {
                var user = new User()
                {
                    Email = model.Email,
                    GivenName = model.GivenName,
                    MiddleName = model.MiddleName,
                    FamilyName = model.FamilyName,
                    FullName = model.FullName,
                    IsActive = true,
                    IsMailConfirmed = false,
                    MustChangePassword = false,
                    Username = model.Email,
                    IsPublic = model.IsPublic
                };

                user.Password = passwordHasher.HashPassword(user, model.Password);
                _context.Users.Add(user);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string GetVerificationCode(string username)
        {
            var passphrase = Guid.NewGuid()
                .ToString()
                .Substring(0, 10);
            var code = username.Encrypt(passphrase);

            return String.Concat(passphrase, code);
        }

        public User GetUserByVerificationCode(string code)
        {
            var passphrase = code.Substring(0, 10);
            var username = code.Substring(10).Decrypt(passphrase);

            return GetUserByUsername(username);
        }

        public string GetPasswordChangeCode(string username)
        {
            var user = GetUserByUsername(username);

            if (user == null)
            {
                throw new ApplicationException($"User with username '{username}' does not exist");
            }

            var passphrase = Guid.NewGuid()
                .ToString()
                .Substring(0, 10);
            var rawCode = String.Concat(username, "password:", user.Password);
            var code = rawCode.Encrypt(passphrase);

            return String.Concat(passphrase, code);
        }

        public User GetUserByPasswordChangeCode(string code)
        {
            var passphrase = code.Substring(0, 10);
            var rawCode = code.Substring(10).Decrypt(passphrase);
            var codeParts = rawCode.Split("password:", StringSplitOptions.RemoveEmptyEntries);

            if (codeParts.Length != 2)
            {
                throw new ArgumentException("Invalide code");
            }

            var user = GetUserByUsername(codeParts[0]);

            if (user?.Password != codeParts[1])
            {
                throw new ArgumentException("The code has expired");
            }

            return user;
        }

        public bool ConfirmEmail(User user)
        {
            bool result = false;
            try
            {
                user.IsMailConfirmed = true;
                _context.Users.Update(user);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool ChangePassword(ChangePasswordViewModel model)
        {
            var result = false;
            var passwordHasher = new PasswordHasher<User>();

            try
            {
                var user = GetUserByPasswordChangeCode(model.Code);

                user.Password = passwordHasher.HashPassword(user, model.Password);
                user.MustChangePassword = false;

                _context.Users.Update(user);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception)
            {

            }

            return result;
        }

        public IQueryable<UserVM> Select_UserVM(bool onlyActive, bool onlyConfirmed, bool onlyInternal)
        {
            bool? active = null;
            if (onlyActive)
            {
                active = true;
            }

            bool? confirmed = null;
            if (onlyConfirmed)
            {
                confirmed = true;
            }
            bool? internalUsers = null;
            if (onlyInternal)
            {
                internalUsers = false;
            }
            return _context.Users
                        .Where(x => x.IsActive == (active ?? x.IsActive)
                        && x.IsMailConfirmed == (confirmed ?? x.IsMailConfirmed)
                        && x.IsPublic == (internalUsers ?? x.IsPublic))
                        .Select(x => new UserVM
                        {
                            UserId = x.Id,
                            Username = x.Username,
                            FullName = x.FullName,
                            IsActive = x.IsActive,
                            IsConfirmed = x.IsMailConfirmed,
                            IsInternal = !x.IsPublic
                        })
                        .OrderBy(x => x.FullName)
                        .AsQueryable();
        }
        /*                 
         *      Legacy Migrations                
         */
        public void MigrateOldUsers()
        {
            var passwordHasher = new PasswordHasher<User>();

            var oldUsers = _context.vOldUsers.OrderByDescending(x => x.CreateDate).ToList();
            foreach (var model in oldUsers)
            {

                try
                {
                    var user = new User()
                    {
                        Email = model.Email,
                        GivenName = model.FirstName,
                        //MiddleName = model.MiddleName,
                        FamilyName = model.LastName,
                        FullName = model.FirstName + " " + model.LastName,
                        Organization = model.Organization,
                        Phone = model.Phone,
                        CreateDate = model.CreateDate,
                        IsActive = true,
                        IsMailConfirmed = true,
                        MustChangePassword = false,
                        Username = model.UserName,
                        IsPublic = true,
                        OldId = model.UserId
                    };

                    user.Password = passwordHasher.HashPassword(user, model.Password);
                    _context.Users.Add(user);
                    _context.SaveChanges();


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
