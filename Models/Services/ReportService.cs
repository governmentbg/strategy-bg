using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Models.Context;
using Models.ViewModels;
using Models.Contracts;
using OfficeOpenXml;
using System.IO;

using Microsoft.AspNetCore.Hosting;



namespace Models.Services
{
    public class ReportService : IReportService
    {
        private readonly MainContext db;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportService(IHostingEnvironment hostingEnvironment, MainContext _db)
        {
            _hostingEnvironment = hostingEnvironment;
            db = _db;
        }


        #region ReportAppPerson
        /// <summary>
        ///Зарежда данни за Списък на командированите / изпратените лица в рамките на предоставянето на услуги

        /// Филтри
        //1.	Командировани или изпратени лица
        //(чрез номенклатурата Вид на формуляра)  По позиция № 3 от регистъра
        //2.	Граждани на държави от ЕС(ДА или НЕ)   По позиция № 10.4 от регистъра
        //3.	Гражданин на държава... (чрез номенклатура Държави)	По позиция № 10.4 от регистъра
        //4.	Продължителност на командироване в дни ОТ и ДО  По разликата в дни на позиции № 8.2
        //     и 8.1 от регистъра
        //5.	Характер на предоставените услуги / дейност на командирования
        //или изпратения работник или служител
        //(чрез номенклатура Характер на дейността)   По позиция № 10.8 от регистъра
        //6.	Място на работа - област(чрез номенклатура ЕКАТТЕ) По позиция № 9.1 от регистъра
        //7.	Период ОТ(начална дата) ДО(крайна дата)
        //(в справката да се включат командированите / изпратените лица,
        //за които поне един ден от командировката им попада в избрания период)	По позиции № 8.1 и № 8.2 от регистъра
        //8.	Период ОТ и ДО на датата на регистриране    По позиция № 2 от регистъра


        /// </summary>
        /// <param name="applicationTypeId">Командировани или изпратени лица</param>
        /// <param name="esCitizenship">Граждани на държави от ЕС(ДА или НЕ)   По позиция № 10.4 от регистъра</param>
        /// <param name="citizenshipId">Гражданин на държава... (чрез номенклатура Държави)	По позиция № 10.4 от регистъра</param>
        /// <param name="stayDurationFromDays">Продължителност на командироване в дни ОТ   По разликата в дни на позиции № 8.2</param>
        /// <param name="StayDurationToDays">Продължителност на командироване в дни  ДО  По разликата в дни на позиции № 8.2</param>
        /// <param name="activityTypeId">	Характер на предоставените услуги / дейност на командирования
        /// или изпратения работник или служител
        //(чрез номенклатура Характер на дейността)   По позиция № 10.8 от регистъра</param>
        /// <param name="RegionId">Място на работа - област(чрез номенклатура ЕКАТТЕ) По позиция № 9.1 от регистъра</param>
        /// <param name="periodStayFrom">Период ОТ(начална дата) </param>
        /// <param name="PeriodStayTo">ДО(крайна дата)</param>
        ///  //(в справката да се включат командированите / изпратените лица,
        //за които поне един ден от командировката им попада в избрания период)	По позиции № 8.1 и № 8.2 от регистъра
        /// <param name="periodRegistrationFrom">Период ОТ на датата на регистриране    По позиция № 2 от регистъра</param>
        /// <param name="periodRegistrationTo">Период  ДО на датата на регистриране    По позиция № 2 от регистъра</param>
        /// <returns></returns>
        public IQueryable<ReportAppPersonVM> ReportAppPerson_Select(int? applicationTypeId, int? countryType, int? citizenshipId, int? stayDurationFromDays,
                                                              int? StayDurationToDays, int? activityTypeId, string areaCode, DateTime? periodStayFrom,
                                                              DateTime? PeriodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {




            var p = db.ApplicationPersons
                .Include(x => x.Person)
                .Include(x => x.DocumentType)
                .Include(x => x.CitizenshipCountry)
                .Include(x => x.ActivityType)
                .Include(x => x.Application)
                .ThenInclude(x => x.LocalAddress)


                .Include(x => x.Application)
                   .Where(x => x.Application.ApplicationTypeId == (applicationTypeId ?? x.Application.ApplicationTypeId))
                   .Where(x => x.CitizenshipCountryId == (citizenshipId ?? x.CitizenshipCountryId))
                   .Where(x => x.CitizenshipCountry.CountryTypeId == (countryType ?? x.CitizenshipCountry.CountryTypeId))
                   .Where(x => x.ActivityTypeId == (activityTypeId ?? x.ActivityTypeId))
                   .Where(x => (((x.Application.SendDateTo - x.Application.SendDateFrom).Days >= (stayDurationFromDays ?? 0)) && ((x.Application.SendDateTo - x.Application.SendDateFrom).TotalDays <= (StayDurationToDays ?? 999999))))
                   //.Where(x => x.Application.ActivityTypeId == (activityTypeId ?? x.Application.ActivityTypeId))
                   .Where(x => x.Application.LocalAddress.AreaCode == (areaCode ?? x.Application.LocalAddress.AreaCode))


                   .Where(x => (x.Application.SendDateFrom <= (PeriodStayTo ?? x.Application.SendDateFrom)) && (x.Application.SendDateTo >= (periodStayFrom ?? x.Application.SendDateTo)))
                   .Where(x => ((x.Application.RegistrationDate >= (periodRegistrationFrom ?? x.Application.RegistrationDate)) && (x.Application.RegistrationDate <= (periodRegistrationTo ?? x.Application.RegistrationDate))))

                   .Select(x => new ReportAppPersonVM
                   {
                       AppPersonFullName = x.Person.FullName,
                       DocumentType = x.DocumentType.NameBG,
                       DocumentNumber = x.DocumentNumber,
                       DocumentTypeAndNumber = x.DocumentType.NameBG + ':' + x.DocumentNumber,
                       Citizenship_country = x.CitizenshipCountry.NameBG,
                       ActivityType = x.ActivityType.NameBG,
                       Send_date_from = x.Application.SendDateFrom.ToString(GlobalConstants.DateFormat),
                       Send_date_to = x.Application.SendDateTo.ToString(GlobalConstants.DateFormat),
                       Period_in_days = (x.Application.SendDateTo - x.Application.SendDateFrom).Days,
                       Registration_number_date = x.Application.RegistrationNumber + '/' + (x.Application.RegistrationDate.HasValue ? x.Application.RegistrationDate.Value.ToString(GlobalConstants.DateFormat) : "")
                   }
                    ).AsQueryable();


            var i = p.ToList();






            return p;
        }

        public bool ExportAppPersonToExcel()
        {
            bool result = false;

            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"ExportTests.xlsx";

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {



                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Test");


                worksheet.Cells[1, 1].Value = "Customer ID";
                worksheet.Cells[1, 2].Value = "Customer Name";
                worksheet.Cells[1, 3].Value = "Customer Email";
                worksheet.Cells[1, 4].Value = "customer Country";
                int i = 0;
                for (int row = 2; row <= 5; row++)
                {
                    worksheet.Cells[row, 1].Value = 1;
                    worksheet.Cells[row, 2].Value = 2;
                    worksheet.Cells[row, 3].Value = 3;
                    worksheet.Cells[row, 4].Value = 4;
                    i++;
                }

                package.Save();

            }

            return (result);
        }




        public Stream GetExportToExcelStream()
        {
            var stream = new System.IO.MemoryStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {


                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Test");


                worksheet.Cells[1, 1].Value = "Customer ID";
                worksheet.Cells[1, 2].Value = "Customer Name";
                worksheet.Cells[1, 3].Value = "Customer Email";
                worksheet.Cells[1, 4].Value = "customer Country";
                int i = 0;
                for (int row = 2; row <= 5; row++)
                {
                    worksheet.Cells[row, 1].Value = 1;
                    worksheet.Cells[row, 2].Value = 2;
                    worksheet.Cells[row, 3].Value = 3;
                    worksheet.Cells[row, 4].Value = 4;
                    i++;
                }
                package.Save();
            }
            stream.Position = 0;
            return (stream);
        }


        #endregion

        #region ReportLocalPerson

        //        Списък на местните лица, приемащи командирования / изпратения работник / служител
        //Филтри
        //1.	Командировани или изпратени лица
        //(чрез номенклатурата Вид на формуляра)  По позиция № 3 от регистъра
        //2.	Област(чрез номенклатура ЕКАТТЕ)   По позиция № 9.1 от регистъра
        //3.	Община(ако е избрана област с Филтър 2) (чрез номенклатура ЕКАТТЕ)	По позиция № 9.1 от регистъра
        //4.	Характер на дейността(чрез номенклатура Характер на дейността) По позиция № 9.3.5 от регистъра
        //5.	Вид на местното лице    По позиция № 9.3.2 от регистъра
        //6.	Период ОТ(начална дата) ДО(крайна дата)
        //(в справката да се включат само тези лица, които са приели командировани /
        //изпратени лица, за поне един ден от избрания период)	По позиции № 8.1 и № 8.2 от регистъра
        //7.	Период ОТ и ДО на датата на регистриране    По позиция № 2 от регистъра
        /// <summary>
        /// <param name="applicationTypeId"> Командировани или изпратени лица По позиция № 3 от регистъра</param>
        /// <param name="area_Code">Област(чрез номенклатура ЕКАТТЕ)   По позиция № 9.1 от регистъра</param>
        /// <param name="municipality_code">Община(ако е избрана област с Филтър 2) (чрез номенклатура ЕКАТТЕ)	По позиция № 9.1 от регистъра</param>
        /// <param name="activityTypeId">Характер на дейността(чрез номенклатура Характер на дейността) По позиция № 9.3.5 от регистъра</param>
        /// <param name="local_entity_typeID">Вид на местното лице    По позиция № 9.3.2 от регистъра</param>
        /// <param name="periodStayFrom">Период ОТ(начална дата) </param>
        /// <param name="PeriodStayTo">Период  ДО(крайна дата)</param>
        /// <param name="periodRegistrationFrom">Период ОТ  датата на регистриране</param>
        /// <param name="periodRegistrationTo">Период  ДО на датата на регистриране</param>
        /// </summary>

        public IQueryable<ReportLocalPersonVM> ReportLocalPerson_Select(int? applicationTypeId, string area_Code, string municipality_code,
                                                    int? activityTypeId, int? local_entity_typeID, DateTime? periodStayFrom,
                                                  DateTime? PeriodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {
            var p = db.Applications

                 .Where(x => x.ApplicationTypeId == (applicationTypeId ?? x.ApplicationTypeId))
                .Where(x => (((x.SendDateFrom >= (periodStayFrom ?? x.SendDateFrom)) && (x.SendDateFrom <= (PeriodStayTo ?? x.SendDateFrom))) || ((x.SendDateTo >= (periodStayFrom ?? x.SendDateTo)) && (x.SendDateTo <= (PeriodStayTo ?? x.SendDateTo)))))
                   .Where(x => ((x.RegistrationDate >= (periodRegistrationFrom ?? x.RegistrationDate)) && (x.RegistrationDate <= (periodRegistrationTo ?? x.RegistrationDate))))
                .Include(x => x.LocalPerson)
                .Include(x => x.LocalPerson).ThenInclude(x => x.IdentifierType)
               .Include(x => x.LocalAddress).ThenInclude(x => x.Area)
               .Include(x => x.LocalAddress).ThenInclude(x => x.Municipality)
               .Include(x => x.LocalAddress).ThenInclude(x => x.City)

               .Include(x => x.LocalActivityType)
                .Where(x => x.LocalAddress.AreaCode == (area_Code ?? x.LocalAddress.AreaCode))
                       .Where(x => x.LocalAddress.MunicipalityCode == (municipality_code ?? x.LocalAddress.MunicipalityCode))
                       .Where(x => x.LocalEntityTypeId == (local_entity_typeID ?? x.LocalEntityTypeId))

                .Where(x => x.LocalActivityTypeId == (activityTypeId ?? x.LocalActivityTypeId))
                .Select(x => new ReportLocalPersonVM


                {
                    IdentifierType = x.LocalPerson.IdentifierType.NameBG,
                    IdentifierNumber = x.LocalPerson.Identifier,
                    LocalPersonFullName = x.LocalPerson.FullName,
                    ActivityType = x.ActivityType.NameBG,
                    AreaName = (x.LocalAddress.Area != null) ? x.LocalAddress.Area.NameBG : "",
                    MunicipalityName = (x.LocalAddress.Municipality != null) ? x.LocalAddress.Municipality.NameBG : "",
                    City = (x.LocalAddress.City != null) ? x.LocalAddress.City.NameBG : "",
                    FullAddress = x.LocalAddress.StreetAddress,

                    ApplicationPeople_count = db.Applications.Where(y => y.LocalPerson.Identifier == x.LocalPerson.Identifier).Where(y => y.ApplicationTypeId == x.ApplicationTypeId).Select(y => y.PersonCount).Sum(),




                }
                    ).AsQueryable();
            return p;

        }
        #endregion

        #region ReportOrganization
        //        Филтри
        //1.	Командировани или изпратени лица
        //(чрез номенклатурата Вид на формуляра)  По позиция № 3 от регистъра
        //2.	Регистриран в държави от ЕС(ДА или НЕ) По позиция № 4.6.1 от регистъра
        //3.	Регистриран в държава... (чрез номенклатура Държави)	По позиция № 4.6.1 от регистъра
        //4.	Продължителност на командироване в брой дни ОТ и ДО По разликата в дни на позиции № 8.2
        // 	и 8.1 от регистъра
        //5.	Характер на дейността(чрез номенклатура Характер на дейността) По позиция № 4.5 от регистъра
        //6.	Период ОТ(начална дата) ДО(крайна дата)
        //(в справката да се включат само тези лица, които са командировали /
        //изпратили лица, за поне един ден от избрания период)	По позиции № 8.1 и № 8.2 от регистъра
        //7.	Период ОТ и ДО на датата на регистриране    По позиция № 2 от регистъра


        /// <summary>

        /// <returns></returns>
        public IQueryable<ReportOrganizationVM> ReportOrganizationVM_Select(int? applicationTypeId, int? countryType, int? citizenshipId,
                                                               int? activityTypeId, int? stayDurationFromDays,
                                                              int? StayDurationToDays, DateTime? periodStayFrom,
                                                              DateTime? PeriodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {





            var p = db.Applications

               //.Where(x => x.ApplicationTypeId == applicationTypeId)
               //.Where(x => (((x.SendDateFrom >= (periodStayFrom ?? x.SendDateFrom)) && (x.SendDateFrom <= (PeriodStayTo ?? x.SendDateFrom))) || ((x.SendDateTo >= (periodStayFrom ?? x.SendDateTo)) && (x.SendDateTo <= (PeriodStayTo ?? x.SendDateTo)))))
               //.Where(x => ((x.RegistrationDate >= (periodRegistrationFrom ?? x.RegistrationDate)) && (x.RegistrationDate <= (periodRegistrationTo ?? x.RegistrationDate))))
               .Include(x => x.ActivityType)
               .Include(x => x.OrganizationPerson)
               .Include(x => x.OrganizationPerson)
               .Include(x => x.HeadquatersAddress)
               .Include(x => x.HeadquatersAddress).ThenInclude(x => x.Country)
                  .Where(x => x.ApplicationTypeId == (applicationTypeId ?? x.ApplicationTypeId))
                   .Where(x => x.HeadquatersAddress.CountryId == (citizenshipId ?? x.HeadquatersAddress.CountryId))
                   .Where(x => x.HeadquatersAddress.Country.CountryTypeId == (countryType ?? x.HeadquatersAddress.Country.CountryTypeId))
                   .Where(x => x.ActivityTypeId == (activityTypeId ?? x.ActivityTypeId))

                   ///////////////////////////////////////////////////////////////////////////////



                   .Where(x => (x.SendDateFrom <= (PeriodStayTo ?? x.SendDateFrom)) && (x.SendDateTo >= (periodStayFrom ?? x.SendDateTo)))
                   .Where(x => ((x.RegistrationDate >= (periodRegistrationFrom ?? x.RegistrationDate)) && (x.RegistrationDate <= (periodRegistrationTo ?? x.RegistrationDate))))


                  //////////////////////////////////////////////////////////////////////////

                  .Select(x => new ReportOrganizationVM

                  {
                      Identifier = x.OrganizationPerson.Identifier,
                      PersonFullName = x.OrganizationPerson.FullName,
                      ActivityType = x.ActivityType.NameBG,
                      Organization_country = x.HeadquatersAddress.Country.NameBG,
                      ApplicationPeople_count = db.Applications.Where(y => y.OrganizationPerson.Identifier == x.OrganizationPerson.Identifier).Where(y => y.ApplicationTypeId == x.ApplicationTypeId).Select(y => y.PersonCount).Sum(),
                      Applications_count = db.Applications.Where(y => y.OrganizationPerson.Identifier == x.OrganizationPerson.Identifier).Where(y => y.ApplicationTypeId == x.ApplicationTypeId).Count()




                  }
                    ).AsQueryable();









            return p;
        }

        #endregion

        #region FullRegisterReport

        //        Обобщена справка
        
        public Stream ReportFullRegister_Select()
     


        {
            var p = db.ApplicationPersons
                .Include(x => x.Person)
                .Include(x => x.CitizenshipCountry)
                .Include(x => x.BirthCountry)
                .Include(x => x.DocumentType)
               .Include(x => x.Address)
               .Include(x => x.Address).ThenInclude(x => x.Country)
                    .Include(x => x.Address).ThenInclude(x => x.Country)
                .Include(x => x.CitizenshipCountry)
                      .Include(x => x.DocumentType)
                .Include(x => x.ActivityType)
                .Include(x => x.Application)
                .Include(x => x.Application).ThenInclude(x => x.OrganizationPerson)

                .Include(x => x.Application).ThenInclude(x => x.ApplicationType)
                .Include(x => x.Application).ThenInclude(x => x.ActivityType)
                .Include(x => x.Application).ThenInclude(x => x.HeadquatersAddress)
                  .Include(x => x.Application).ThenInclude(x => x.HeadquatersAddress).ThenInclude(x => x.Country)

                      .Include(x => x.Application).ThenInclude(x => x.PosteAddress)
                  .Include(x => x.Application).ThenInclude(x => x.PosteAddress).ThenInclude(x => x.Country)


                  .Include(x => x.Application).ThenInclude(x => x.OfficialPerson)
            .Include(x => x.Application).ThenInclude(x => x.OfficialAddress)
                 .Include(x => x.Application).ThenInclude(x => x.OfficialAddress).ThenInclude(x => x.Country)


                  .Include(x => x.Application).ThenInclude(x => x.ContactAddress).ThenInclude(x => x.Country)
                         .Include(x => x.Application).ThenInclude(x => x.ContactPerson)
                      .Include(x => x.Application).ThenInclude(x => x.ContactPerson).ThenInclude(x => x.IdentifierType)
                            .Include(x => x.Application).ThenInclude(x => x.ContactAddress)
                                .Include(x => x.Application).ThenInclude(x => x.ContactAddress).ThenInclude(x => x.Country)

                                 .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Country)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Area)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Municipality)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.City)


                                     .Include(x => x.Application).ThenInclude(x => x.LocalPerson)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalEntityType)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.City)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalActivityType)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalPerson).ThenInclude(x => x.IdentifierType)





                                 .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Country)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Area)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Municipality)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.City)

          

                .ToArray();



            var stream = new System.IO.MemoryStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {


                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Register");
                int row_ofset = 1;
                //Командировано лице
                worksheet.Cells[row_ofset, 1].Value = "10.1 Пълното име на командирования";
                worksheet.Cells[row_ofset, 2].Value = "10.2 Дата на раждане";
                worksheet.Cells[row_ofset, 3].Value = "10.3.1 Държава на раждане";
                worksheet.Cells[row_ofset, 4].Value = "10.3.2 Населено място на раждане";

                worksheet.Cells[row_ofset, 5].Value = "10.4 Гражданство";
                worksheet.Cells[row_ofset, 6].Value = "10.5 Вид на личния документ";
                worksheet.Cells[row_ofset, 7].Value = "10.6 Номер на личния документ";
                worksheet.Cells[row_ofset, 8].Value = "10.7 Постоянен адрес";
                worksheet.Cells[row_ofset, 9].Value = "10.8 Характер на предоставените услуги";

                worksheet.Cells[row_ofset, 10].Value = "1 Регистрационен номер";
                worksheet.Cells[row_ofset, 11].Value = "2 Дата и час на регистриране";
                worksheet.Cells[row_ofset, 12].Value = "3 Вид на формуляра";
                worksheet.Cells[row_ofset, 13].Value = "4.1 Име на командироващото / изпращащото лице";
                worksheet.Cells[row_ofset, 14].Value = "4.2 Представлявано от";
                worksheet.Cells[row_ofset, 15].Value = "4.3 Идентификационен №";

                worksheet.Cells[row_ofset, 17].Value = "4.5 Характер на дейността ";
                worksheet.Cells[row_ofset, 18].Value = "4.6 Седалище и адрес на управление";
                worksheet.Cells[row_ofset, 19].Value = "4.7 Адрес за кореспонденция:";
                worksheet.Cells[row_ofset, 20].Value = "5.1/5.2 Лице за осъществяване на връзка с компетентните органи в Република България за получаване и изпращане на документи ";
                worksheet.Cells[row_ofset,21].Value = "5.3 Адрес за кореспонденция";
                worksheet.Cells[row_ofset,22].Value = "6 Лице за контакт, ако е необходимо, което действа като представител, чрез който съответните социални партньори могат да се опитват да привлекат работодателя към участие в колективно трудово договаряне за срока на предоставянето на услугите";
                worksheet.Cells[row_ofset,23].Value = "6.3 Адрес за кореспонденция";
                worksheet.Cells[row_ofset,24].Value = "7 Брой командировани / изпратени лица";
                worksheet.Cells[row_ofset,25].Value = "8.1 Начална дата на командироването или изпращането";
                worksheet.Cells[row_ofset,26].Value = "8.2 Крайна дата на командироването или изпращането";
                worksheet.Cells[row_ofset,27].Value = "9 Място на командироване / изпращане-Адрес";
                worksheet.Cells[row_ofset,28].Value = "9.3 3.1 Местното лице, приемащо на работа командирования или изпратения работник или служител";
                worksheet.Cells[row_ofset,29].Value = "9.3.2 Вид на местното лице";
                worksheet.Cells[row_ofset,30].Value = "9.3.3. 9.3.3.4 Вид на идентификатора   и номер идентификатора на местното лице";
                worksheet.Cells[row_ofset,31].Value = "9.3.5 Характер на дейността ";
                worksheet.Cells[row_ofset,32].Value = "9.3.6 Адрес по регистрация на местното лице";
                worksheet.Cells[row_ofset,33].Value = "11 Заявител ";
              
                int i = p.Count();
                row_ofset++;
                for (int row = 0; row < i; row++)
                {
                    //Командировано лице
                    worksheet.Cells[row + row_ofset, 1].Value = p[row].Person.FullName;
                    worksheet.Cells[row + row_ofset, 2].Value = p[row].BirthDate;
                    worksheet.Cells[row + row_ofset, 3].Value = p[row].BirthCountry.NameBG;
                    worksheet.Cells[row + row_ofset, 4].Value = p[row].BirthPlace;

                    worksheet.Cells[row + row_ofset, 5].Value = p[row].CitizenshipCountry.NameBG;

                    worksheet.Cells[row + row_ofset, 6].Value = p[row].DocumentType.NameBG;
                    worksheet.Cells[row + row_ofset, 8].Value = p[row].Address.Country.NameBG + ", " + p[row].Address.Settlement + ", +" + p[row].Address.StreetAddress;
                    worksheet.Cells[row + row_ofset, 9].Value = p[row].ActivityType.NameBG;
                    worksheet.Cells[row + row_ofset, 10].Value = p[row].Application.RegistrationNumber;
                    worksheet.Cells[row + row_ofset, 11].Value = p[row].Application.RegistrationDate;
                    worksheet.Cells[row + row_ofset, 12].Value = p[row].Application.ApplicationType.NameBG;
                    worksheet.Cells[row + row_ofset, 13].Value = p[row].Application.OrganizationPerson.FullName;
                    worksheet.Cells[row + row_ofset, 14].Value = p[row].Application.RepresentedBy;
                    worksheet.Cells[row + row_ofset, 15].Value = p[row].Application.OrganizationPerson.Identifier;
                    if (p[row].Application.ApplicationTypeId == GlobalConstants.ApplicationTypes.Posting)
                    {
                        worksheet.Cells[row_ofset, 16].Value = "4.4 Номер на регистрация за извършване на дейност като ПОВР";
                        worksheet.Cells[row + row_ofset, 16].Value = p[row].Application.POVR_RegistrationNumber;
                    }

                    worksheet.Cells[row + row_ofset, 17].Value = p[row].Application.ActivityType.NameBG;
                    worksheet.Cells[row + row_ofset, 18].Value = p[row].Application.HeadquatersAddress.Country.NameBG + " ," + p[row].Application.HeadquatersAddress.Settlement + "ПК:" + p[row].Application.HeadquatersAddress.PostCode + ", " + p[row].Application.HeadquatersAddress.StreetAddress;
                    worksheet.Cells[row + row_ofset, 19].Value = p[row].Application.PosteAddress.Country.NameBG + " ," + p[row].Application.PosteAddress.Settlement + "ПК:" + p[row].Application.PosteAddress.PostCode + ", " + p[row].Application.PosteAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.PosteAddress.PhoneFax + ", Електронна поща" + p[row].Application.PosteAddress.Email;


                    worksheet.Cells[row + row_ofset, 20].Value = p[row].Application.OfficialPerson.FullName + "," + p[row].Application.OfficialPerson.IdentifierType.NameBG + ":" + p[row].Application.OfficialPerson.Identifier;

                    
                    worksheet.Cells[row + row_ofset, 21].Value = p[row].Application.OfficialAddress.Country.NameBG + " ," + p[row].Application.OfficialAddress.Settlement + "ПК:" + p[row].Application.OfficialAddress.PostCode + ", " + p[row].Application.OfficialAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.OfficialAddress.PhoneFax + ", Електронна поща" + p[row].Application.OfficialAddress.Email;



                    worksheet.Cells[row + row_ofset, 22].Value = p[row].Application.ContactPerson.FullName + "," + p[row].Application.ContactPerson.IdentifierType.NameBG + ":" + p[row].Application.ContactPerson.Identifier;


                    worksheet.Cells[row + row_ofset, 23].Value = p[row].Application.ContactAddress.Country.NameBG + " ," + p[row].Application.ContactAddress.Settlement + "ПК:" + p[row].Application.ContactAddress.PostCode + ", " + p[row].Application.ContactAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.ContactAddress.PhoneFax + ", Електронна поща" + p[row].Application.ContactAddress.Email;

                    worksheet.Cells[row + row_ofset, 24].Value = p[row].Application.PersonCount;

                    worksheet.Cells[row + row_ofset, 25].Value = p[row].Application.SendDateFrom;
                    worksheet.Cells[row + row_ofset, 26].Value = p[row].Application.SendDateTo;
                


                       
                        worksheet.Cells[row + row_ofset, 27].Value = "Област:" + p[row].Application.LocalAddress.Area.NameBG +
                                                       ", Община:" + p[row].Application.LocalAddress.Municipality.NameBG +
                                                       ", Населено място:" + p[row].Application.LocalAddress.City.NameBG +
                                                       ", " + p[row].Application.OfficialAddress.StreetAddress;
                    
                    worksheet.Cells[row + row_ofset, 28].Value = p[row].Application.LocalPerson.FullName;
                    worksheet.Cells[row + row_ofset, 29].Value = p[row].Application.LocalEntityType.NameBG;

                    worksheet.Cells[row + row_ofset, 30].Value = p[row].Application.LocalPerson.IdentifierType.NameBG + ":" + p[row].Application.LocalPerson.Identifier;


                    worksheet.Cells[row + row_ofset, 31].Value = p[row].Application.LocalActivityType.NameBG;
               
                        worksheet.Cells[row + row_ofset, 32].Value = "Област:" + p[row].Application.LocalLegalAddress.Area.NameBG +
                                                   ", Община:" + p[row].Application.LocalLegalAddress.Municipality.NameBG +
                                                   ", Населено място:" + p[row].Application.LocalLegalAddress.City.NameBG +
                                                   ", " + p[row].Application.LocalLegalAddress.StreetAddress;
                 
                        worksheet.Cells[row + row_ofset, 33].Value = "";
                    
                }
                package.Save();
            }
            stream.Position = 0;
            return (stream);
        }



        //        Обобщена справка
        //Филтри
        //1.	Регистрационен номер    По позиция № 1 от регистъра
        //2.	Командировани или изпратени лица
        //(чрез номенклатурата Вид на формуляра)  По позиция № 3 от регистъра
        //3.	Идентификационен номер на командироващото / изпращащото лице    По позиция № 4.3 от регистъра
        //4.	Името(или част от него) на командироващото / изпращащото лице  По позиция № 4.1 от регистъра
        //5.	Регистриран в държава от ЕС(ДА или НЕ) По позиция № 4.6.1 от регистъра
        //6.	Регистриран в държава... (чрез номенклатура Държави)	По позиция № 4.6.1 от регистъра
        //7.	Характер на дейността(чрез номенклатура Характер на дейността) По позиция № 4.5 от регистъра
        //8.	Вид и номер на личен документ на командированото / изпратеното лице     По позиция № 10.5 и 10.6 от регистъра
        //9.	Името(или част от него) на командированото / изпратеното лице  По позиция № 10.1 от регистъра
        //10.	Граждани на държави от ЕС(ДА или НЕ)   По позиция № 10.4 от регистъра
        //11.	Гражданин на държава... (чрез номенклатура Държави)	По позиция № 10.4 от регистъра
        //12.	Характер на предоставените услуги / дейност на командирования
        //или изпратения работник или служител
        //(чрез номенклатура Характер на дейността)   По позиция № 10.8 от регистъра
        //13.	Името(или част от него) на местното лице По позиция № 9.3.1 от регистъра
        //14.	Вид и код на идентификатора на местното лице    По позиция № 9.3.3 и 9.3.4 от регистъра
        //15.	Характер на дейността(чрез номенклатура Характер на дейността) По позиция № 9.3.5 от регистъра
        //16.	Област(чрез номенклатура ЕККАТЕ)   По позиция № 9.1 от регистъра
        //17.	Община(ако е избрана област с Филтър 15) (чрез номенклатура ЕККАТЕ)	По позиция № 9.1 от регистъра
        //18.	Период ОТ(начална дата) ДО(крайна дата)
        //(в справката да се включат само тези лица, които са приели командировани
        /// изпратени лица, за поне един ден от избрания период)	По позиции № 8.1 и № 8.2 от регистъра
        //19.	Период ОТ и ДО на датата на регистриране

        public Stream ReportFullRegister_SelectParams(string register_number,
                                                                          int? application_type_id,
                                                                          string org_identifier,
                                                                          string org_name,
                                                                          int? org_country_id,
                                                                          int? org_country_type,
                                                                          int? activity_type,
                                                                          int? app_person_document_type_id,
                                                                          string app_person_identifier,
                                                                          string app_person_full_name,
                                                                          int? app_person_country_typeid,
                                                                          int? app_person_citizenship_id,
                                                                          int? app_person_activity_type_id,
                                                                        
                                                                        
                                                                          string local_person_full_name,
                                                                          string local_person_identifier,
                                                                          int? local_person_activity_type_id,
                                                                          string local_person_area_code,
                                                                          string local_person_municipality_code,
                                                                          DateTime? periodStayFrom,
                                                                          DateTime? PeriodStayTo,
                                                                          DateTime? periodRegistrationFrom,
                                                                          DateTime? periodRegistrationTo)


        {
            var p = db.ApplicationPersons
                .Include(x => x.Person)
                .Include(x => x.CitizenshipCountry)
                .Include(x => x.BirthCountry)
                .Include(x => x.DocumentType)
               .Include(x => x.Address)
               .Include(x => x.Address).ThenInclude(x => x.Country)
                    .Include(x => x.Address).ThenInclude(x => x.Country)
                .Include(x => x.CitizenshipCountry)
                      .Include(x => x.DocumentType)
                .Include(x => x.ActivityType)
                .Include(x => x.Application)
                .Include(x => x.Application).ThenInclude(x => x.OrganizationPerson)

                .Include(x => x.Application).ThenInclude(x => x.ApplicationType)
                .Include(x => x.Application).ThenInclude(x => x.ActivityType)
                .Include(x => x.Application).ThenInclude(x => x.HeadquatersAddress)
                  .Include(x => x.Application).ThenInclude(x => x.HeadquatersAddress).ThenInclude(x => x.Country)

                      .Include(x => x.Application).ThenInclude(x => x.PosteAddress)
                  .Include(x => x.Application).ThenInclude(x => x.PosteAddress).ThenInclude(x => x.Country)


                  .Include(x => x.Application).ThenInclude(x => x.OfficialPerson)
            .Include(x => x.Application).ThenInclude(x => x.OfficialAddress)
                 .Include(x => x.Application).ThenInclude(x => x.OfficialAddress).ThenInclude(x => x.Country)


                  .Include(x => x.Application).ThenInclude(x => x.ContactAddress).ThenInclude(x => x.Country)
                         .Include(x => x.Application).ThenInclude(x => x.ContactPerson)
                      .Include(x => x.Application).ThenInclude(x => x.ContactPerson).ThenInclude(x => x.IdentifierType)
                            .Include(x => x.Application).ThenInclude(x => x.ContactAddress)
                                .Include(x => x.Application).ThenInclude(x => x.ContactAddress).ThenInclude(x => x.Country)

                                 .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Country)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Area)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.Municipality)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.City)


                                     .Include(x => x.Application).ThenInclude(x => x.LocalPerson)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalEntityType)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalAddress).ThenInclude(x => x.City)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalActivityType)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalPerson).ThenInclude(x => x.IdentifierType)





                                 .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Country)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Area)
                                   .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.Municipality)
                                     .Include(x => x.Application).ThenInclude(x => x.LocalLegalAddress).ThenInclude(x => x.City)


            //                         /////////////////////////////////////////////////////////Application
            //string register_number,
            //                                                              int? application_type_id,
            //                                                              string org_identifier,
            //                                                              string org_name,
            //                                                              int? org_country_id,
            //                                                              int? org_country_type,
            //                                                              int? activity_type,
                                                                          
                                                                          
            //                                                              DateTime? periodStayFrom,
            //                                                              DateTime? PeriodStayTo,
            //                                                              DateTime? periodRegistrationFrom,
            //                                                              DateTime? periodRegistrationTo)
            .Where(x=>x.Application.RegistrationNumber.Contains(register_number?? x.Application.RegistrationNumber))
            .Where(x => x.Application.ActivityTypeId == (application_type_id ?? x.Application.ActivityTypeId))
              .Where(x => x.Application.OrganizationPerson.Identifier.Contains(org_identifier ?? x.Application.OrganizationPerson.Identifier))
              .Where(x => x.Application.OrganizationPerson.FullName.Contains(org_name ?? x.Application.OrganizationPerson.FullName))
                .Where(x => x.Application.HeadquatersAddress.CountryId == (org_country_id ?? x.Application.HeadquatersAddress.CountryId))
                  .Where(x=>x.Application.HeadquatersAddress.Country.CountryTypeId==(org_country_type??x.Application.HeadquatersAddress.Country.CountryTypeId))
                  .Where(x => x.ActivityTypeId == (activity_type ?? x.ActivityTypeId))

                          .Where(x => (x.Application.SendDateFrom <= (PeriodStayTo ?? x.Application.SendDateFrom)) && (x.Application.SendDateTo >= (periodStayFrom ?? x.Application.SendDateTo)))
                   .Where(x => ((x.Application.RegistrationDate >= (periodRegistrationFrom ?? x.Application.RegistrationDate)) && (x.Application.RegistrationDate <= (periodRegistrationTo ?? x.Application.RegistrationDate))))


            ///////////////////////////////////////////////////////////////////////////////




            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////ApplicationPerson///////////////////////////

            //int? app_person_document_type_id,
            //   string app_person_identifier,
            //   string app_person_full_name,
            //   int? app_person_country_typeid,
            //   int? app_person_citizenship_id,
            //   int? app_person_activity_type_id,
            //   int? countryType, int? citizenshipId,
            .Where(x =>(x.Person.IdentifierTypeId == (app_person_document_type_id ?? x.Person.IdentifierTypeId)))
           .Where(x=>x.Person.Identifier.Contains (app_person_identifier ?? x.Person.Identifier))
          .Where(x => x.Person.FullName.Contains(local_person_full_name ?? x.Person.FullName))
             .Where(x => x.CitizenshipCountryId == (app_person_citizenship_id ?? x.CitizenshipCountryId))
             .Where(x => x.CitizenshipCountry.CountryTypeId == (app_person_country_typeid ?? x.CitizenshipCountry.CountryTypeId))
             .Where(x => x.ActivityTypeId == (app_person_activity_type_id ?? x.ActivityTypeId))



            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////local person

            //                                                              string local_person_full_name,
            //                                                              string local_person_identifier,
            //                                                              int? local_person_activity_type_id,
            //                                                              string local_person_area_code,
            //                                                              string local_person_municipality_code,
            .Where(x=>x.Application.LocalPerson.FullName.Contains(local_person_full_name?? x.Application.LocalPerson.FullName))
             .Where(x => x.Application.LocalPerson.Identifier.Contains(local_person_identifier ?? x.Application.LocalPerson.Identifier))
             .Where(x=>x.Application.LocalActivityTypeId==(local_person_activity_type_id?? x.Application.LocalActivityTypeId))
               .Where(x => x.Application.LocalAddress.AreaCode == (local_person_area_code ?? x.Application.LocalAddress.AreaCode))
               .Where(x => x.Application.LocalAddress.MunicipalityCode == (local_person_municipality_code ?? x.Application.LocalAddress.MunicipalityCode))
                           ////////////////////////////////////////////////////////////////////////

                .ToArray();



            var stream = new System.IO.MemoryStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {


                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Register");
                int row_ofset = 1;
                //Командировано лице
                worksheet.Cells[row_ofset, 1].Value = "10.1 Пълното име на командирования";
                worksheet.Cells[row_ofset, 2].Value = "10.2 Дата на раждане";
                worksheet.Cells[row_ofset, 3].Value = "10.3.1 Държава на раждане";
                worksheet.Cells[row_ofset, 4].Value = "10.3.2 Населено място на раждане";

                worksheet.Cells[row_ofset, 5].Value = "10.4 Гражданство";
                worksheet.Cells[row_ofset, 6].Value = "10.5 Вид на личния документ";
                worksheet.Cells[row_ofset, 7].Value = "10.6 Номер на личния документ";
                worksheet.Cells[row_ofset, 8].Value = "10.7 Постоянен адрес";
                worksheet.Cells[row_ofset, 9].Value = "10.8 Характер на предоставените услуги";

                worksheet.Cells[row_ofset, 10].Value = "1 Регистрационен номер";
                worksheet.Cells[row_ofset, 11].Value = "2 Дата и час на регистриране";
                worksheet.Cells[row_ofset, 12].Value = "3 Вид на формуляра";
                worksheet.Cells[row_ofset, 13].Value = "4.1 Име на командироващото / изпращащото лице";
                worksheet.Cells[row_ofset, 14].Value = "4.2 Представлявано от";
                worksheet.Cells[row_ofset, 15].Value = "4.3 Идентификационен №";

                worksheet.Cells[row_ofset, 17].Value = "4.5 Характер на дейността ";
                worksheet.Cells[row_ofset, 18].Value = "4.6 Седалище и адрес на управление";
                worksheet.Cells[row_ofset, 19].Value = "4.7 Адрес за кореспонденция:";
                worksheet.Cells[row_ofset, 20].Value = "5.1/5.2 Лице за осъществяване на връзка с компетентните органи в Република България за получаване и изпращане на документи ";
                worksheet.Cells[row_ofset, 21].Value = "5.3 Адрес за кореспонденция";
                worksheet.Cells[row_ofset, 22].Value = "6 Лице за контакт, ако е необходимо, което действа като представител, чрез който съответните социални партньори могат да се опитват да привлекат работодателя към участие в колективно трудово договаряне за срока на предоставянето на услугите";
                worksheet.Cells[row_ofset, 23].Value = "6.3 Адрес за кореспонденция";
                worksheet.Cells[row_ofset, 24].Value = "7 Брой командировани / изпратени лица";
                worksheet.Cells[row_ofset, 25].Value = "8.1 Начална дата на командироването или изпращането";
                worksheet.Cells[row_ofset, 26].Value = "8.2 Крайна дата на командироването или изпращането";
                worksheet.Cells[row_ofset, 27].Value = "9 Място на командироване / изпращане-Адрес";
                worksheet.Cells[row_ofset, 28].Value = "9.3 3.1 Местното лице, приемащо на работа командирования или изпратения работник или служител";
                worksheet.Cells[row_ofset, 29].Value = "9.3.2 Вид на местното лице";
                worksheet.Cells[row_ofset, 30].Value = "9.3.3. 9.3.3.4 Вид на идентификатора   и номер идентификатора на местното лице";
                worksheet.Cells[row_ofset, 31].Value = "9.3.5 Характер на дейността ";
                worksheet.Cells[row_ofset, 32].Value = "9.3.6 Адрес по регистрация на местното лице";
                worksheet.Cells[row_ofset, 33].Value = "11 Заявител ";

                int i = p.Count();
                row_ofset++;
                for (int row = 0; row < i; row++)
                {
                    //Командировано лице
                    worksheet.Cells[row + row_ofset, 1].Value = p[row].Person.FullName;
                    worksheet.Cells[row + row_ofset, 2].Value = p[row].BirthDate;
                    worksheet.Cells[row + row_ofset, 3].Value = p[row].BirthCountry.NameBG;
                    worksheet.Cells[row + row_ofset, 4].Value = p[row].BirthPlace;

                    worksheet.Cells[row + row_ofset, 5].Value = p[row].CitizenshipCountry.NameBG;

                    worksheet.Cells[row + row_ofset, 6].Value = p[row].DocumentType.NameBG;
                    worksheet.Cells[row + row_ofset, 8].Value = p[row].Address.Country.NameBG + ", " + p[row].Address.Settlement + ", +" + p[row].Address.StreetAddress;
                    worksheet.Cells[row + row_ofset, 9].Value = p[row].ActivityType.NameBG;
                    worksheet.Cells[row + row_ofset, 10].Value = p[row].Application.RegistrationNumber;
                    worksheet.Cells[row + row_ofset, 11].Value = p[row].Application.RegistrationDate;
                    worksheet.Cells[row + row_ofset, 12].Value = p[row].Application.ApplicationType.NameBG;
                    worksheet.Cells[row + row_ofset, 13].Value = p[row].Application.OrganizationPerson.FullName;
                    worksheet.Cells[row + row_ofset, 14].Value = p[row].Application.RepresentedBy;
                    worksheet.Cells[row + row_ofset, 15].Value = p[row].Application.OrganizationPerson.Identifier;
                    if (p[row].Application.ApplicationTypeId == GlobalConstants.ApplicationTypes.Posting)
                    {
                        worksheet.Cells[row_ofset, 16].Value = "4.4 Номер на регистрация за извършване на дейност като ПОВР";
                        worksheet.Cells[row + row_ofset, 16].Value = p[row].Application.POVR_RegistrationNumber;
                    }

                    worksheet.Cells[row + row_ofset, 17].Value = p[row].Application.ActivityType.NameBG;
                    worksheet.Cells[row + row_ofset, 18].Value = p[row].Application.HeadquatersAddress.Country.NameBG + " ," + p[row].Application.HeadquatersAddress.Settlement + "ПК:" + p[row].Application.HeadquatersAddress.PostCode + ", " + p[row].Application.HeadquatersAddress.StreetAddress;
                    worksheet.Cells[row + row_ofset, 19].Value = p[row].Application.PosteAddress.Country.NameBG + " ," + p[row].Application.PosteAddress.Settlement + "ПК:" + p[row].Application.PosteAddress.PostCode + ", " + p[row].Application.PosteAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.PosteAddress.PhoneFax + ", Електронна поща" + p[row].Application.PosteAddress.Email;


                    worksheet.Cells[row + row_ofset, 20].Value = p[row].Application.OfficialPerson.FullName + "," + p[row].Application.OfficialPerson.IdentifierType.NameBG + ":" + p[row].Application.OfficialPerson.Identifier;


                    worksheet.Cells[row + row_ofset, 21].Value = p[row].Application.OfficialAddress.Country.NameBG + " ," + p[row].Application.OfficialAddress.Settlement + "ПК:" + p[row].Application.OfficialAddress.PostCode + ", " + p[row].Application.OfficialAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.OfficialAddress.PhoneFax + ", Електронна поща" + p[row].Application.OfficialAddress.Email;



                    worksheet.Cells[row + row_ofset, 22].Value = p[row].Application.ContactPerson.FullName + "," + p[row].Application.ContactPerson.IdentifierType.NameBG + ":" + p[row].Application.ContactPerson.Identifier;


                    worksheet.Cells[row + row_ofset, 23].Value = p[row].Application.ContactAddress.Country.NameBG + " ," + p[row].Application.ContactAddress.Settlement + "ПК:" + p[row].Application.ContactAddress.PostCode + ", " + p[row].Application.ContactAddress.StreetAddress + ", Телефон / факс:" + p[row].Application.ContactAddress.PhoneFax + ", Електронна поща" + p[row].Application.ContactAddress.Email;

                    worksheet.Cells[row + row_ofset, 24].Value = p[row].Application.PersonCount;

                    worksheet.Cells[row + row_ofset, 25].Value = p[row].Application.SendDateFrom;
                    worksheet.Cells[row + row_ofset, 26].Value = p[row].Application.SendDateTo;




                    worksheet.Cells[row + row_ofset, 27].Value = "Област:" + p[row].Application.LocalAddress.Area.NameBG +
                                                   ", Община:" + p[row].Application.LocalAddress.Municipality.NameBG +
                                                   ", Населено място:" + p[row].Application.LocalAddress.City.NameBG +
                                                   ", " + p[row].Application.OfficialAddress.StreetAddress;

                    worksheet.Cells[row + row_ofset, 28].Value = p[row].Application.LocalPerson.FullName;
                    worksheet.Cells[row + row_ofset, 29].Value = p[row].Application.LocalEntityType.NameBG;

                    worksheet.Cells[row + row_ofset, 30].Value = p[row].Application.LocalPerson.IdentifierType.NameBG + ":" + p[row].Application.LocalPerson.Identifier;


                    worksheet.Cells[row + row_ofset, 31].Value = p[row].Application.LocalActivityType.NameBG;

                    worksheet.Cells[row + row_ofset, 32].Value = "Област:" + p[row].Application.LocalLegalAddress.Area.NameBG +
                                               ", Община:" + p[row].Application.LocalLegalAddress.Municipality.NameBG +
                                               ", Населено място:" + p[row].Application.LocalLegalAddress.City.NameBG +
                                               ", " + p[row].Application.LocalLegalAddress.StreetAddress;

                    worksheet.Cells[row + row_ofset, 33].Value = "";

                }
                package.Save();
            }
            stream.Position = 0;
            return (stream);
        }
        #endregion
        static string NullToString(object Value)
        {

           
            return Value == null ? "" : Value.ToString();



        }
    }
}
