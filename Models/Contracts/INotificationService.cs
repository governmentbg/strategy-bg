using Models.Context;
using Models.Contracts;
using Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using WebCommon.Services;
using WebCommon;
using Models.Context.Notifications;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Models.ViewModels.Portal;
namespace Models.Contracts
{
    public interface INotificationService : IBaseService
    {

        bool InsertNotificationMessages(String messageTitle, string messageBody, int SourceID, int sourceType, bool systemNotification, bool emailNotification, List<UserToNotificateVM> userToNotificate);


        SystemNotificationVM CurrentUserSystemNotification(int userNotificationId);

        bool CurrentUserSystemNotification_MarkAsRead(int userNotificationId);

        int CurrentUserSystemNotification_NewMessages();
        IQueryable<SystemNotificationVM> CurrentUserSystemNotification_List();


        Task SendingInsertedNotifications();
    }
}
