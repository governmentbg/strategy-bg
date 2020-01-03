using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context.Account;
using Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebCommon.Models;
using WebCommon.Services;

namespace Models.Contracts
{
    public interface IAccountService : IBaseService
    {
        //Legacy
        vOldUser ValidateUser_Old(string username, string password);

        #region Auth

        void GeneratePasswordHash();
        bool AreUserCredentialsValid(string username, string password);
        ClaimsPrincipal GeneratePrincipalByUsername(string username);
        ClaimsPrincipal Users_LoginRegisterExternalAuth(ClaimsPrincipal extPrincipal);

        #endregion

        #region Users

        IQueryable<UserVM> Users_Select(string fullName, string userName, int? userType, bool? isApproved);
        Users Users_GetByUserName(string username);
        UserEditVM Users_GetById(int id);
        bool Users_Update(UserEditVM model);
        bool Users_UpdateProfile(UserEditVM model);
        bool Users_RegisterInternal(RegisterInternalUserVM model);
        bool Users_RegisterPublic(RegisterPublicUserVM model, bool autoConfirmMain = false);
        string Users_CheckRegistration(RegisterInternalUserVM model);
        string Users_GenerateVerificationCode(string username);
        Users Users_GetByVerificationCode(string code);
        bool Users_ConfirmAndApproveMail(Users model);

        bool Users_ChangePassword(ChangePasswordViewModel model);

        IEnumerable<SelectListItem> Combo_UserTypes();
        #endregion

        #region Roles & Groups

        IQueryable<Groups> Groups_Select();
        bool Groups_SaveData(Groups model);

        IQueryable<GroupUserVM> GroupUsers_Select(int? id = null);
        bool GroupUsers_SaveData(GroupUserVM model);

        UserRolesVM UserRoles_Select(int userId);
        bool UserRoles_Save(UserRolesVM model);

        IQueryable<UserInGroupVM> UserInGroup_Select(int? groupId, int? userId);
        bool UserInGroup_Add(int groupId, int userId);
        bool UserInGroup_Remove(int groupId, int userId);

        bool User_DeactivateUser(string username);

        #endregion

        #region Categories and Target Groups

        IQueryable<UserInCategoryVM> UserInCategories_Select(int? userId, int? categoryId);
        bool UserInCategories_Add(int userId, int categoryId);
        bool UserInCategories_Remove(int userId, int categoryId);

        IQueryable<UserInTargetGroupVM> UserInTargetGroups_Select(int? userId, int? targetGroupId);
        bool UserInTargetGroups_Add(int userId, int targetGroupId);
        bool UserInTargetGroups_Remove(int userId, int targetGroupId);

        UserInCategoriesVM UserInCategoriesVM_Select(int userId);

        bool UserInCategories_SaveAll(int userId, UserInCategoriesVM userInCategories);

        #endregion


        #region Common

        IQueryable<UserToNotificateVM> Users_SelectForNotification(int? userId, int? categoryId, int? targetGroupId, int? groupUserId);

        #endregion
    }
}
