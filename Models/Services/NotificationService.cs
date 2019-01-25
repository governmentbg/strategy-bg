using Models.Context;
using Models.Context.Notifications;
using Models.Contracts;
using Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using WebCommon.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Models.ViewModels.Portal;

namespace Models.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly IUserContext userContext;
        private readonly IEmailSender emailSender;
        public NotificationService(MainContext _db, IUserContext _userContext, IEmailSender _emailSender)

        {
            db = _db;
            userContext = _userContext;
            emailSender = _emailSender;

        }

        public IQueryable<SystemNotificationVM> CurrentUserSystemNotification_List()
        {
            return All<UserNotifications>()
                                        .Include(x => x.NotificationMessage)
                                     .Include(x => x.SystemStatusTable)
                                        .Where(x => x.SystemStatus < GlobalConstants.SystemMessageStatus.НеСеИзпраща)
                                        .Where(x => x.NotificationMessage.IsActive == true)
                                        .Where(x => x.UserId == userContext.UserId)
                                    
                        .Select(x => new SystemNotificationVM()
                        {
                            UserNotificationId = x.Id,
                            Title = x.NotificationMessage.Title,
                            Body = x.NotificationMessage.Body,
                            MessageDate = x.NotificationMessage.DateCreated,
                            SystemStatusId = x.SystemStatus,
                            SystemStatusName = x.SystemStatusTable.Title


                        })
                        .OrderByDescending(x=>x.MessageDate)
                        .AsQueryable();
        }
        public bool CurrentUserSystemNotification_MarkAsRead(int userNotificationId)
        {
            bool result = false;
            var notification = db.UserNotifications.Where(x => x.Id == userNotificationId && x.UserId == userContext.UserId && x.SystemStatus == GlobalConstants.SystemMessageStatus.НовоСъобщение)
             .FirstOrDefault();

            if (notification != null)
            {
                notification.SystemStatus = GlobalConstants.SystemMessageStatus.ПрочетеноСъобщение;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return result;

        }

        public int CurrentUserSystemNotification_NewMessages()
        {
            int count = db.UserNotifications.Where(x => x.UserId == userContext.UserId && x.SystemStatus == GlobalConstants.SystemMessageStatus.НовоСъобщение)
              .Count();
            return count;
        }

        public SystemNotificationVM CurrentUserSystemNotification(int userNotificationId)
        {
            return All<UserNotifications>()
                                        .Include(x => x.NotificationMessage)
                                     .Include(x => x.SystemStatusTable)
                                        .Where(x => x.SystemStatus < GlobalConstants.SystemMessageStatus.НеСеИзпраща)
                                        .Where(x => x.NotificationMessage.IsActive == true)
                                        .Where(x => x.UserId == userContext.UserId)
                                        .Where(x => x.Id == userNotificationId)
                        .Select(x => new SystemNotificationVM()
                        {
                            UserNotificationId = x.Id,
                            Title = x.NotificationMessage.Title,
                            Body = x.NotificationMessage.Body,
                            MessageDate = x.NotificationMessage.DateCreated,
                            SystemStatusId = x.SystemStatus,
                            SystemStatusName = x.SystemStatusTable.Title


                        }).FirstOrDefault();
        }
        public bool InsertNotificationMessages(String messageTitle, string messageBody, int sourceID, int sourceType, bool systemNotification, bool emailNotification, List<UserToNotificateVM> listToNotificate)
        {
            bool result = false;
            try
            {


                NotificationMessages notificationMessage = new NotificationMessages
                {
                    Title = messageTitle,
                    Body = messageBody,
                    SourceID = sourceID,
                    SourceType = sourceType,
                    SystemNotification = systemNotification,
                    EmailNotification = emailNotification,
                    IsActive = true,
                    CreatedByUserId = userContext.UserId,
                    DateCreated = DateTime.Now,
                    ModifiedByUserId = userContext.UserId,
                    DateModified = DateTime.Now
                };

                foreach (var user in listToNotificate)

                {
                    UserNotifications userNotification = new UserNotifications();
                    userNotification.UserId = user.UserId;
                    userNotification.Email = user.Email;
                    userNotification.SystemStatus = (systemNotification) ? GlobalConstants.SystemMessageStatus.НовоСъобщение : GlobalConstants.SystemMessageStatus.НеСеИзпраща;
                    userNotification.EmailStatus = (emailNotification) ? GlobalConstants.EmailStatus.НовоСъобщение : GlobalConstants.EmailStatus.НеСеИзпраща;
                    userNotification.DateEmailStatus = DateTime.Now;
                    userNotification.DateSystemStatus = DateTime.Now;
                    // userNotification.MessageID = notificationMessage.Id;
                    notificationMessage.UserNotifications.Add(userNotification);

                }
                db.NotificationMessages.Add(notificationMessage);
                db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
        public async Task SendingInsertedNotifications()
        {
            List<NotificationMessages> notifications = All<NotificationMessages>()
                                  .Include(x => x.UserNotifications)
                                  .Where(x => x.UserNotifications.Any(i => i.EmailStatus < GlobalConstants.EmailStatus.НеСеИзпраща))
                                  .Where(x => x.IsActive == true)
                                  .ToList();
            while (notifications.Count > 0)
            {


                foreach (var message in notifications)
                {
                    string[] mailList = new string[message.UserNotifications.Count()];
                    int i = 0;
                    foreach (var userToSend in message.UserNotifications)
                    {
                        mailList[i] = userToSend.Email;
                        i = i + 1;

                    }
                    try
                    {
                        await emailSender.SendMail(mailList, message.Title, message.Body);
                        foreach (var userToSend in message.UserNotifications)
                        {
                            userToSend.EmailStatus = GlobalConstants.EmailStatus.УспешноИзпратен;
                            userToSend.DateEmailStatus = DateTime.Now;

                        }
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        foreach (var userToSend in message.UserNotifications)
                        {
                            userToSend.EmailStatus = (userToSend.EmailStatus == GlobalConstants.EmailStatus.НеуспешенОпит9) ? GlobalConstants.EmailStatus.НеСеИзпращаПоради10НевалидниОпита : userToSend.EmailStatus + 1;
                            userToSend.DateEmailStatus = DateTime.Now;

                        }
                        db.SaveChanges();
                    }

                }
                await Task.Delay(20000);
                notifications = All<NotificationMessages>()
                                    .Include(x => x.UserNotifications)
                                    .Where(x => x.UserNotifications.Any(i => i.EmailStatus < GlobalConstants.EmailStatus.НеСеИзпраща))
                                    .Where(x => x.IsActive == true)
                                    .ToList();
            }
        }


    }
}
