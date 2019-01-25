using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models;
using Models.Context;
using Models.ViewModels.Plugins;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Models.ViewModels;
using WebCommmon.Controllers;
using Models.Context.Application;
using DataTables.AspNet.Core;
using WebCommon.Extensions;
using DataTables.AspNet.AspNetCore;
using WebCommon.Services;


namespace Domain.Controllers
{
    /// <summary>
    /// Номенклатура на държави
    /// </summary>
    [Authorize]
    public class CountriesController : BaseController
    {
        private readonly INomService NomService;

        public CountriesController(INomService _countryService)
        {
            NomService = _countryService;

        }
        public IActionResult Index()  // to do add language
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request)
        {


            var data = NomService.Country_Select();
            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.NameBG.Contains(request.Search.Value ?? x.NameBG));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }


        public IActionResult Add()
        {
            var model = new Country()
            {
                IsActive = true,
            };
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Add(Country model)
        {
            //ТОДО: 


            if (ModelState.IsValid)
            {
                if (NomService.Country_SaveData(model))
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", model);
        }
        public IActionResult Edit(int id)
        {
            var model = NomService.Country_GetByID(id);
            SetViewBag(model);
            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Country model)
        {
                        
            if (ModelState.IsValid)
            {
                if (NomService.Country_SaveData(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Edit", model);
        }

        private void SetViewBag(Country model)
        {
            ViewBag.countryName = model.NameBG;
            ViewBag.CountryType = NomService.CountryType_Combo().ToSelectList(model.CountryTypeId).AddAllItem("Изберете", null);
            ViewBag.RiskCategory = NomService.RiskCategory_Combo().ToSelectList(model.RiskCategoryId).AddAllItem("Изберете", null);
        }



    }
}