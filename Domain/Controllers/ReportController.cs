using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models;
using Models.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebCommmon.Controllers;
using DataTables.AspNet.Core;
using WebCommon.Extensions;
using DataTables.AspNet.AspNetCore;
using WebCommon.Services;
using System;
using Models.Context.Application;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace Domain.Controllers
{
    /// <summary>
    /// Модул Справки
    /// </summary>
    [Authorize]
    public class ReportController : BaseController
    {
        private readonly IReportService reportService;
        private readonly INomService nomService;
        private readonly IUserContext userContext;

        private readonly MainContext db;

        public ReportController(IReportService _reportService, INomService _nomService, IUserContext _userContext, MainContext _db)
        {
            reportService = _reportService;
            nomService = _nomService;
            userContext = _userContext;

            db = _db;
        }
        public async Task<IActionResult> ExportToExcel()
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
           
            string fileName = @"Subscribers.xlsx";
            string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            stream.Position = 0;
            return File(stream, fileType, fileName);
        }

        public async Task<IActionResult> ExportStreamToExcel()
        {
            Stream stream = reportService.ReportFullRegister_Select();


            string fileName = @"Subscribers.xlsx";
            string fileType = "application/vnd.ms-excel";
            //string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream, fileType, fileName);
        }

        public async Task<IActionResult> ExportFullRegisterToExcel()
        {
            Stream stream = reportService.ReportFullRegister_Select();


            string fileName = @"Register.xlsx";
            string fileType = "application/vnd.ms-excel";
            //string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream, fileType, fileName);
        }
        public IActionResult AppPerson()
        {
            ViewBag.applicationTypeId = nomService.All<ApplicationType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem(); 
            ViewBag.countryType = nomService.CountryType_Combo().ToSelectList(x => x.Value, x => x.Text).AddAllItem();

            ViewBag.citizenshipId = nomService.Country_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem(); 
            ViewBag.activityTypeId = nomService.ActivityType_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem(); 
            ViewBag.areaCode = nomService.Ekkate_Select(GlobalConstants.DefaultLang,"-1").ToSelectList(x => x.Value, x => x.Text).AddAllItem();

            return View("AppPerson");
        }
        [HttpPost]
        public IActionResult LoadDataAppPerson(IDataTablesRequest request, int? applicationTypeId, int? countryType, int? citizenshipId, int? stayDurationFromDays,
                                                              int? stayDurationToDays, int? activityTypeId, string areaCode, DateTime? periodStayFrom,
                                                              DateTime? periodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {

            var data = reportService.ReportAppPerson_Select(applicationTypeId.EmptyToNull(), countryType.EmptyToNull(), citizenshipId.EmptyToNull(), stayDurationFromDays,
                                                               stayDurationToDays, activityTypeId.EmptyToNull(), areaCode.EmptyToNull(), periodStayFrom.MakeFromDate(),
                                                               periodStayTo.MakeToDate(), periodRegistrationFrom.MakeFromDate(), periodRegistrationTo.MakeToDate());
            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.AppPersonFullName.Contains(request.Search.Value ?? x.AppPersonFullName));
            }
            var response = request.GetResponse(data);
          
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult AppOrganization()
        {
            ViewBag.applicationTypeId = nomService.All<ApplicationType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            ViewBag.countryType = nomService.CountryType_Combo().ToSelectList(x => x.Value, x => x.Text).AddAllItem();

            ViewBag.citizenshipId = nomService.Country_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem();
            ViewBag.activityTypeId = nomService.ActivityType_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem();
        
            return View("AppOrganization");
        }

        public IActionResult FullRegister()
        {
            ViewBag.applicationTypeId = nomService.All<ApplicationType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            ViewBag.countryType = nomService.CountryType_Combo().ToSelectList(x => x.Value, x => x.Text).AddAllItem();
            ViewBag.local_entity_typeID = nomService.All<LocalEntityType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();

            ViewBag.citizenshipId = nomService.Country_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem();
            ViewBag.activityTypeId = nomService.ActivityType_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem();
            ViewBag.app_person_document_type_id = nomService.All<DocumentType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            return View("FullRegister");
        }

        [HttpPost]
        public IActionResult FullRegister(string register_number,int? application_type_id,
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
            


            string fileName = @"Register.xlsx";
            string fileType = "application/vnd.ms-excel";
            //string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           

            Stream stream= reportService.ReportFullRegister_SelectParams(register_number.EmptyToNull(),
                                                                                 application_type_id.EmptyToNull(),
                                                                                  org_identifier.EmptyToNull(),
                                                                                org_name.EmptyToNull(),
                                                                                 org_country_id.EmptyToNull(),
                                                                                  org_country_type.EmptyToNull(),
                                                                                   activity_type.EmptyToNull(),
                                                                                   app_person_document_type_id.EmptyToNull(),
                                                                                  app_person_identifier.EmptyToNull(),
                                                                                   app_person_full_name.EmptyToNull(),
                                                                                   app_person_country_typeid.EmptyToNull(),
                                                                                   app_person_citizenship_id.EmptyToNull(),
                                                                                   app_person_activity_type_id.EmptyToNull(),
                                                                           

                                                                                   local_person_full_name.EmptyToNull(),
                                                                                 local_person_identifier.EmptyToNull(),
                                                                                  local_person_activity_type_id.EmptyToNull(),
                                                                                  local_person_area_code.EmptyToNull(),
                                                                                   local_person_municipality_code.EmptyToNull(),
                                                                                   periodStayFrom,
                                                                                   PeriodStayTo,
                                                                                   periodRegistrationFrom,
                                                                                   periodRegistrationTo);

            return File(stream, fileType, fileName);
        }
        [HttpPost]
        public IActionResult LoadDataAppOrganization(IDataTablesRequest request, int? applicationTypeId, int? countryType, int? citizenshipId,
                                                               int? activityTypeId, int? stayDurationFromDays,
                                                              int? stayDurationToDays, DateTime? periodStayFrom,
                                                              DateTime? periodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {

            var data = reportService.ReportOrganizationVM_Select(applicationTypeId.EmptyToNull(), countryType.EmptyToNull(),  citizenshipId.EmptyToNull(),
                                                                activityTypeId.EmptyToNull(), stayDurationFromDays.EmptyToNull(),
                                                              stayDurationToDays.EmptyToNull(), periodStayFrom.MakeFromDate(),
                                                             periodStayTo.MakeToDate(), periodRegistrationFrom.MakeFromDate(), periodRegistrationTo.MakeToDate());

          


            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.PersonFullName.Contains(request.Search.Value ?? x.PersonFullName));
            }
            var response = request.GetResponse(data);
          
            return new DataTablesJsonResult(response, true);
        }
        public IActionResult LocalPerson()
        {
            ViewBag.applicationTypeId = nomService.All<ApplicationType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            ViewBag.local_entity_typeID= nomService.All<LocalEntityType>(x => x.IsActive == true).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
     
            ViewBag.areaCode = nomService.Ekkate_Select(GlobalConstants.DefaultLang, "-1").ToSelectList(x => x.Value, x => x.Text).AddAllItem();
          
            ViewBag.activityTypeId= nomService.ActivityType_Select(GlobalConstants.DefaultLang).ToSelectList(x => x.Value, x => x.Text).AddAllItem();

            return View("LocalPerson");
        }
        [HttpPost]
        public IActionResult LoadDataLocalPerson(IDataTablesRequest request, int? applicationTypeId, string areaCode, string municipalityCode,
                                                   int? activityTypeID,int? local_entity_typeID , DateTime? periodStayFrom,
                                                 DateTime? PeriodStayTo, DateTime? periodRegistrationFrom, DateTime? periodRegistrationTo)
        {

            var data = reportService.ReportLocalPerson_Select(applicationTypeId.EmptyToNull(), areaCode, municipalityCode,
                                                   activityTypeID.EmptyToNull(), local_entity_typeID.EmptyToNull(), periodStayFrom.MakeFromDate(),
                                                  PeriodStayTo.MakeToDate(), periodRegistrationFrom.MakeFromDate(), periodRegistrationTo.MakeToDate());
            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.LocalPersonFullName.Contains(request.Search.Value ?? x.LocalPersonFullName));
            }
            var response = request.GetResponse(data);

            return new DataTablesJsonResult(response, true);
        }

    }
}