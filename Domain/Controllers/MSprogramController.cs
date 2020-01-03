using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
//using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Consultations;
using Models.Context.Questionary;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Controllers
{
    public class MSprogramController : BasePortalController
    {
        private readonly IConsultationService consultationService;
        private readonly INomenclatureService nomService;
        private readonly ICommentService commentService;
        private readonly IUrlHelper urlHelper;
        public MSprogramController(
            IConsultationService _consultationService,
            INomenclatureService _nomService,
            ICommentService _commentService,
            IUrlHelper _urlHelper)
        {
            consultationService = _consultationService;
            nomService = _nomService;
            commentService = _commentService;
            urlHelper = _urlHelper;
        }
        public IActionResult LawPrograms()
        {
            ViewBag.programType = GlobalConstants.MSProgramTypes.Zakonodatelna;

            return View("Programs");
        }
        public IActionResult OpPrograms()
        {
            ViewBag.programType = GlobalConstants.MSProgramTypes.Operativna;

            return View("Programs");
        }

        [HttpPost]
        public IActionResult LoadData_Programs(IDataTablesRequest request, int programType, string searchTerm)
        {
            string sanitizedSearch = searchTerm.EmptyToNull();
            var data = consultationService.Program_Select(this.Lang, programType, sanitizedSearch).Where(x => x.IsActive == true).OrderByDescending(x => x.Title);
            var filteredData = data.AsQueryable();

            var orderColums = request.Columns.Where(x => x.Sort != null);
            var page = filteredData.OrderBy(orderColums).Skip(request.Start).Take((request.Length > 0) ? request.Length : filteredData.Count());

            return new DataTablesJsonResult(DataTablesResponse.Create(request, data.Count(), filteredData.Count(), page), true);
        }

        public IActionResult Projects(int id)
        {
            var program = consultationService.Find<MSProgram>(id);
            if (program == null || !program.IsActive)
            {
                return View("NotFound");
            }
            ViewBag.program = program;
            return View();
        }
        [HttpPost]
        public IActionResult LoadData_Projects(IDataTablesRequest request, int programId, string searchTerm)
        {
            string sanitizedSearch = searchTerm.EmptyToNull();
            var data = consultationService.ProgramProject_Select(this.Lang, programId, sanitizedSearch).Where(x => x.IsActive == true).OrderByDescending(x => x.DateCoordinated);
            var filteredData = data.AsQueryable();

            var orderColums = request.Columns.Where(x => x.Sort != null);
            var page = filteredData.OrderBy(orderColums).Skip(request.Start).Take((request.Length > 0) ? request.Length : filteredData.Count());

            return new DataTablesJsonResult(DataTablesResponse.Create(request, data.Count(), filteredData.Count(), page), true);
        }

        public IActionResult Project(int id)
        {
            var model = consultationService.ProgramProject_GetById(id);
            if (model == null || !model.IsActive)
            {
                return View("NotFound");
            }
            ViewBag.program = consultationService.Find<MSProgram>(model.MSProgramId);
            ViewBag.consultation = consultationService.GetConsultationByProject(id);
            return View(model);
        }

    }
}