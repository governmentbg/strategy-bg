using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.Class
{
    public class MessageConstant
    {
        /// <summary>
        /// Грешка
        /// </summary>
        public const string ErrorMessage = "ErrorMessage";

        /// <summary>
        /// Внимание
        /// </summary>
        public const string WarningMessage = "WarningMessage";

        /// <summary>
        /// Успех
        /// </summary>
        public const string SuccessMessage = "SuccessMessage";

        /// <summary>
        /// Не е избран (за Display Template-ите)
        /// </summary>
        public const string NotSelected = "Не е избран";

        /// <summary>
        /// Не е избран (за Display Template-ите)
        /// </summary>
        public const string Yes = "Да";

        /// <summary>
        /// Не е избран (за Display Template-ите)
        /// </summary>
        public const string No = "Не";

        public class EmailMessages
        {
            public const string ConfirmMailSubject = "Потвърждение на регистрация";

            public const string ConfirmMail = "Здравейте,<br />Вашата регистрация в '{0}' беше успешна. За да потвърдите адреса си за електронна поща, моля последвайте <a href='{1}'>следната хипервръзка</a>.<br />Това съобщение е генерирано автоматично, моля не отговаряйте.";

            public const string ChangePasswordSubject = "Забравена парола";

            public const string ChangePassword = "Здравейте,<br />Вие получавате този мейл защото сте поискали да смените паролата си в '{0}'. Ако не желаете да промените паролата си, моля игнорирайте това съобщение.<br />За смяна на паролата, моля щракнете <a href='{1}'>тук.</a><br />Това съобщение е генерирано автоматично, моля не отговаряйте.";
        }

        public class Values
        {
            public const string SaveOK = "Записът премина успешно.";
            public const string SaveFailed = "Проблем по време на запис.";
            public const string RemoveOk = "Елементът е премахнат успешно.";
            public const string UpdateOK = "Обновяването премина успешно.";
            public const string UpdateFailed = "Проблем при обновяването на данните.";
            public const string LoginFailed = "Грешно потребителско име или парола.";
            public const string InvalidCertificate = "Невалиден сертификат.";
            public const string InvalidEmail = "Невалиден адрес на електронна поща.";
            public const string InvalidUser = "Невалиден потребител.";
            public const string ConfirmEmailSent = "На вашата електронна поща беше изпратено съобщение за потвърждение.";
            public const string EmailFailed = "Възникна проблем при изпращането на съобщение.";
            public const string NotForADUsers = "Тази услуга не е достъпна за потребители от Активната Директория!";
            public const string FileNotFound = "Файлът не е намерен!";

        }
    }
}
