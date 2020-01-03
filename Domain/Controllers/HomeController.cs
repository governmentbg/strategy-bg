using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Elastic.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using System.Linq;
using System.Threading.Tasks;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Controllers
{
    public class HomeController : BasePortalController
    {
        private readonly ISearchService searchService;
        private readonly IAccountService accountService;
        private readonly IQuestionaryService questionaryService;
        public HomeController(IAccountService _accountService, ISearchService _searchService, IQuestionaryService _questionaryService)
        {
            accountService = _accountService;
            searchService = _searchService;
            questionaryService = _questionaryService;
        }

        public IActionResult Index()
        {
            ViewBag.hasNewQuestionary = questionaryService.GetQuestionaries(1)?.Count() > 0;
            return View();
        }
        public IActionResult SamplePage()
        {
            return View();
        }


        public IActionResult Message(bool isError = false)
        {
            MessageDialogVM model = this.GetMessageDialog();
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public IActionResult Search(string searchPhrase = "")
        {
            ViewBag.searchPhrase = searchPhrase;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search_LoadData(IDataTablesRequest request, string searchPhrase)
        {
            var data = await searchService.Search(searchPhrase, request.Start + 1, request.Length);

            var response = request.GetResponse(null, data.Results.AsQueryable(), (int)data.Total);


            return new DataTablesJsonResult(response, true);


        }
    }
}