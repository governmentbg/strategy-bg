using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Elastic.Models.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Consultations;
using WebCommmon.Controllers;


namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class APIsController : BaseController
    {
        private readonly ISearchService searchService;

        public APIsController(ISearchService _searchService)
        {
          searchService = _searchService;
        }

    public IActionResult Index()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    [HttpPost]
    public async Task<IActionResult> SearchDocument(IDataTablesRequest request, string searchPhrase)
    {
      var data = await searchService.Search(searchPhrase, 1, 10);

      var response = request.GetResponse(data.Results.AsQueryable());


      return new DataTablesJsonResult(response, true);


    }
  }
}