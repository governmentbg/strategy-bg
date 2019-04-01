using IdServer.Models.Entities;
using IdServer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace IdServer.Models.Contracts
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        User GetUserById(string userId);
        User GetUserByEmail(string email);
        User GetUserByProvider(string loginProvider, string providerKey);
        IEnumerable<UserLogin> GetUserLoginsByUserId(string userId);
        IEnumerable<Claim> GetClaimsByUserId(string userId, string clientId);
        bool AreUserCredentialsValid(string username, string password, string clientId);
        bool IsUserActive(string userId);
        bool IsInRole(string userId, string clientId, string role);
        void AddUser(User user);
        void AddUserLogin(string userId, string loginProvider, string providerKey);
        void AddClaim(string userId, string claimType, string claimValue);
        bool Save();

        User FindByExternalProvider(string provider, string providerUserId);

        UserEditVM GetUserEditVMBySubjectId(string userId);
        bool SaveUserEdit(UserEditVM model);

        UserRolesVM LoadUserRoles(string userId);
        bool SaveUserRoles(UserRolesVM model);
        bool RegisterUser(RegisterViewModel model);

        string GetVerificationCode(string username);

        User GetUserByVerificationCode(string code);

        string GetPasswordChangeCode(string username);

        User GetUserByPasswordChangeCode(string code);
        bool ConfirmEmail(User user);
        bool ChangePassword(ChangePasswordViewModel model);

        IQueryable<UserVM> Select_UserVM(bool onlyActive, bool onlyConfirmed, bool onlyInternal);

    /*                 
     *      Legacy Migrations                
     */

    void MigrateOldUsers();
    }
}
