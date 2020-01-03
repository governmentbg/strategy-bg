using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels.PCSubjectsModels;
using Rotativa.AspNetCore;
using System.ComponentModel;
using System.Linq;
using WebCommon.Services;

namespace Domain.Controllers
{
    /// <summary>
    /// Public Consultation Subjects
    /// </summary>
    public class PCSubjectsController : BasePortalController
    {
		private readonly IPCSubjectsService PCSubjectsService;
		private readonly IUserContext userContext;

		public PCSubjectsController(IPCSubjectsService _PCSubjectsService, IUserContext _userContext)
		{
			PCSubjectsService = _PCSubjectsService;
			userContext = _userContext;
		}

		#region Public Consultation Subjects
		public IActionResult ListPCSubjects(string name, string eik, int pcSubjectsTypeID)
		{
			SetComboViewBags();

			return View();
		}

		[HttpPost]
		public IActionResult LoadDataPCSubjects(IDataTablesRequest request, string name, string eik, int? pcSubjectsTypeID)
		{
			if (name == null)
			{
				name = "";
			}

			if (eik == null)
			{
				eik = "";
			}

			if (pcSubjectsTypeID == null)
			{
				pcSubjectsTypeID = -1;
			}

			IQueryable<PCSubjectsListViewModel> data = PCSubjectsService.GetPCSubjectsList(name, eik, pcSubjectsTypeID ?? -1);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

    [HttpGet]
    public IActionResult View(int id)
    {
      var model = PCSubjectsService.GetPCSubjects(id);
      SetViewComboViewBags(false);

      return View("View", model);
    }

    private void SetViewComboViewBags(bool addAll = true)
    {
      ViewBag.PCSubjectsTypeID_ddl = PCSubjectsService.GetPCSubjectTypesDDL(addAll);

      ViewBag.catMasters = PCSubjectsService.GetCategoriesDDL(0, null);
      ViewBag.catNational = PCSubjectsService.GetCategoriesDDL(Models.GlobalConstants.Categories.Type_National, null);
      ViewBag.catDistrict = PCSubjectsService.GetCategoriesDDL(Models.GlobalConstants.Categories.Type_District, null);
    }
    private void SetComboViewBags(bool addAll = true)
		{
			ViewBag.PCSubjectsTypeID_ddl = PCSubjectsService.GetPCSubjectTypesDDL(addAll);
		}
		#endregion

		[HttpGet]
		[Description("PDF експорт на лицата по ЗНА")]
		public ActionResult PCSubjectsPDF(string name, string eik, int? pcSubjectsTypeID)
		{
			if (name == null)
			{
				name = "";
			}

			if (eik == null)
			{
				eik = "";
			}

			if (pcSubjectsTypeID == null)
			{
				pcSubjectsTypeID = -1;
			}

			IQueryable<PCSubjectsListViewModel> model = PCSubjectsService.GetPCSubjectsList(name, eik, pcSubjectsTypeID ?? -1);

			return new ViewAsPdf("_PCSubjectsPDF", model.ToList());
		}
	}
}