﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;

namespace Models
{
    /// <summary>
    /// Глобални константи
    /// </summary>
    public class GlobalConstants
    {
        public const string DefaultLang = "bg";
        public const string DateFormat = "dd.MM.yyyy";
        public const int BulgariaCountryId = 155;
        public const int LangBG = 1;
        public static IEnumerable<SelectListItem> EmptyComboList
        {
            get
            {
                return new List<SelectListItem>();
            }
        }

        /// <summary>
        /// Видове статии
        /// </summary>
        public class PageTypes
        {
            public const int Pages = 1;
            public const int Ovos = 2;
        }

        /// <summary>
        /// Статус на статия
        /// </summary>
        public class PageStates
        {
            public const int Draft = 1;
            public const int Published = 2;
            public const int Deleted = 3;
        }

        /// <summary>
        /// Режим на зареждане на външни връзки
        /// </summary>
        public class PagelinkModes
        {
            public const string Self = "_self";
            public const string Blank = "_blank";
            public const string Modal = "_modal";
        }

        /// <summary>
        /// Источник на данни
        /// </summary>
        public class SourceTypes
        {

            public const int News = 1;
            public const int NewsImage = 11;
            public const int Publications = 2;
            public const int PublicationsImages = 21;
            public const int PublicConsultation = 3;
            public const int PublicConsultationDocuments = 31;
            public const int StrategicDocuments = 4;
            public const int Partnership = 5;
            public const int ChangeProposals = 41;
            public const int PartnershipImage = 51;
            public const int NationalPlanElementsDocuments = 52;
            public const int PlanEstimations = 55;
            public const int AboutUs = 61;
            public const int Comment = 6;
            public const int Banner = 7;
            public const int BannerImage = 71;
            public const int Facebook = 8;
            public const int FacebookImage = 81;
            public const int Category = 9;
            public const int CategoryImage = 91;

            public const int Library_Documents = 101;

            public const int Library_Images = 102;

            public const int Library_ImagesThumbs = 103;

            public const int Legacy_Unassigned = 200;

            /// <summary>
            /// //Когато няма наличен изходен обект            
            /// </summary>
            public const int BlancSource = 999;
        }

        /// <summary>
        /// Видове источници на данни
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SourceTypeVM> SourceTypeList()
        {
            List<SourceTypeVM> result = new List<SourceTypeVM>()
                        {
                                new SourceTypeVM(){ Id = SourceTypes.Library_Documents, ListName = "Документи", SingleName="документ"},
                                new SourceTypeVM(){ Id = SourceTypes.Library_Images,ListName = "Изображения", SingleName="изображение"}
                        };
            return result;
        }


        public static SourceTypeVM GetSourceType(int id)
        {
            return SourceTypeList().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Списък в допустими езици
        /// </summary>
        /// <returns></returns>
        public static IQueryable<LangVM> SelectLangs()
        {
            List<LangVM> result = new List<LangVM>() {
                                new LangVM() { Lang = "bg", Title = "Български" },
                                new LangVM() { Lang = "en", Title = "English" }
                        };
            return result.AsQueryable();
        }

        /// <summary>
        /// Режим на позициониране на изображение
        /// </summary>
        public class ImagePositions
        {
            public const int FloatLeft = 1;
            public const int FloatRight = 2;
            public const int BlockLeft = 3;
            public const int BlockRight = 4;
            public const int Inline = 4;
        }
        /// Статус на изпращане на мейл
        public class EmailStatus
        {
            public const int НовоСъобщение = 1;
            public const int НеуспешенОпит1 = 2;
            public const int НеуспешенОпит2 = 3;
            public const int НеуспешенОпит3 = 4;
            public const int НеуспешенОпит4 = 5;
            public const int НеуспешенОпит5 = 6;
            public const int НеуспешенОпит6 = 7;
            public const int НеуспешенОпит7 = 8;
            public const int НеуспешенОпит8 = 9;
            public const int НеуспешенОпит9 = 10;
            public const int НеСеИзпраща = 100;
            public const int УспешноИзпратен = 101;
            public const int НеСеИзпращаПоради10НевалидниОпита = 102;
        }
        /// Статус на изпращане насистемно съобщение
        public class SystemMessageStatus
        {
            public const int НовоСъобщение = 1;
            public const int ПрочетеноСъобщение = 2;
            public const int НеСеИзпраща = 100;

        }
        /// <summary>
        /// Вид на елемент от резултат от търсене
        /// </summary>
        public class SearchItemType
        {
            public const string PageItem = "PageItem";
            public const string DocItem = "DocItem";
        }

        /// <summary>
        /// Съобщения за запис, административна част
        /// </summary>
        public class SaveMessages
        {
            public const string SavedOK = "Записът премина успешно.";
            public const string SavedFailed = "Проблем по времена запис. Моля, опитайте по-късно.";
        }

        /// <summary>
        /// Видове съобщения за потребителя
        /// </summary>
        public class UserMessages
        {
            public const string Title = "UserMessage_Title";
            public const string Success = "UserMessage_Success";
            public const string Warning = "UserMessage_Warning";
            public const string Danger = "UserMessage_Danger";
        }

        public class UserTypes
        {
            public const int Internal = 1;
            public const int Public = 2;
            public const int Group = 3;
        }
        public class Roles
        {
            public const string Admin = "adm";
            public const string AdminGroup = "adm_grp";
            public const string AdminAndAdminGroup = "adm,adm_grp";
            public const string ConsultationsModerator = "consultation_mod";
        }

        public class Language
        {
            public const int Bulgarian = 1;
        }

        public class Questionary
        {
            /// <summary>
            /// Брой отговори (еднакъв за всички въпроси в една анкета от 3 до 6)
            /// </summary>
            public const int QuestionaryMinNumberOfAnswers = 3;

            /// <summary>
            /// Брой отговори (еднакъв за всички въпроси в една анкета от 3 до 6)
            /// </summary>
            public const int QuestionaryMaxNumberOfAnswers = 6;

            /// <summary>
            /// Без мнение - за първи отговор или при неотговорен въпрос
            /// </summary>
            public const string WithoutOpinion = "Без мнение";
        }

        public class Category
        {
            public const int Type_National = 1;
            public const int Type_District = 2;
            public const int Type_Municipal = 3;
        }

        public class ExternalProviders
        {
            public const string Facebook = "Facebook";
            public const string Twitter = "Twitter";
        }

        /// <summary>
        /// Статуси на коментари
        /// </summary>
        public class CommentStatus
        {
            public const int New = 1;
            public const int Disapproved = 2;
            public const int Approved = 3;
            public const int Deleted = 4;
        }

        public class NationalElementTypeCategories
        {
            public const int Plan = 1;
        }

        public class OgpElementTypes
        {
            public const int NationalPlan = 1;
        }
        public class OgpElementStates
        {
            public const int New = 1;
            public const int Actual = 2;
            public const int Completed = 3;
        }

        public class DocumentTypes
        {
            public const int Consultation = 1;
            public const int Evaluation = 2;
            public const int Etalon = 3;
        }
        /// <summary>
        /// Видове оценки
        /// </summary>
        public class EstimationTypes
        {
            /// <summary>
            /// Доклад за самооценка
            /// </summary>
            public const int SelfEstimations = 1;

            /// <summary>
            /// Доклад от независим оценител
            /// </summary>
            public const int ExternalEstimation = 2;
        }
    }



}
