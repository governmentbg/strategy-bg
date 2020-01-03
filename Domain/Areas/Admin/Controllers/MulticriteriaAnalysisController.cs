using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebCommmon.Controllers;
using DataTables.AspNet.Core;
using WebCommon.Extensions;
using DataTables.AspNet.AspNetCore;
using WebCommon.Services;
using Models.Contracts;
using Models.Context.MulticriteriaAnalysis;
using Models;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  public class MulticriteriaAnalysisController : BaseAdminController
    {
        private readonly IMulticriteriaAnalisysService MulticriteriaAnalisysService;
        private readonly IUserContext userContext;

        public MulticriteriaAnalysisController(IMulticriteriaAnalisysService _MulticriteriaAnalisysService, IUserContext _userContext)
        {
            MulticriteriaAnalisysService = _MulticriteriaAnalisysService;
            userContext = _userContext;

        }
        public IActionResult Criteria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadCriteria(IDataTablesRequest request)
        {
            var data = MulticriteriaAnalisysService.Criteria_Select();
            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.Name.Contains(request.Search.Value ?? x.Name));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }


        public IActionResult CriteriaAdd()
        {
            var model = new Criteria()
            {
                IsActive = true,
                UserWrt = userContext.UserId
            };
            SetViewBag(model);
            return View("EditCriteria", model);
        }

        [HttpPost]
        public IActionResult CriteriaAdd(Criteria model)
        {
            if (ModelState.IsValid)
            {
                if (MulticriteriaAnalisysService.Criteria_SaveData(model))
                {
                    return RedirectToAction("Criteria");
                }
            }

            return View("EditCriteria", model);
        }
        public IActionResult EditCriteria(int id)
        {
            var model = MulticriteriaAnalisysService.Criteria_GetByID(id);
            ViewBag.CriteriaName = model.Name;
            SetViewBag(model);
            return View("EditCriteria", model);
        }
        [HttpPost]
        public IActionResult EditCriteria(Criteria model)
        {
            model.UserWrt = userContext.UserId;

            if (ModelState.IsValid)
            {
                if (MulticriteriaAnalisysService.Criteria_SaveData(model))
                {
                    return RedirectToAction("Criteria");
                }
            }
            ViewBag.CriteriaName = model.Name;
            SetViewBag(model);
            return View("EditCriteria", model);
        }


    public IActionResult CriteriaValues(int _CriteriaID)
    {

      ViewBag.CriteriaID = _CriteriaID;
      if (_CriteriaID > 0)
      {
        Criteria _criteria = MulticriteriaAnalisysService.Criteria_GetByID(_CriteriaID);
        ViewBag.CriteriaName = _criteria.Name;
      };
      return View();
    }
    [HttpPost]
    public IActionResult LoadCriteriaValues(IDataTablesRequest request, int _CriteriaID)
    {

      var data = MulticriteriaAnalisysService.CriteriaValue_Select(_CriteriaID);
      var filteredData = data;

      if (request.Search.Value != null)
      {
        filteredData = data.Where(x => x.Name.Contains(request.Search.Value ?? x.Name));
      }
      var response = request.GetResponse(data, filteredData);
      return new DataTablesJsonResult(response, true);
    }


    public IActionResult AddCriteriaValue(int _CriteriaID, string _CriteriaName)
    {
      var model = new CriteriaValue()
      {
        CriteriaId = _CriteriaID
      };
      ViewBag.CriteriaName = _CriteriaName;
      return View("EditCriteriaValues", model);
    }

    [HttpPost]
    public IActionResult AddCriteriaValue(CriteriaValue model)
    {
      SetViewBag(model);

      if (ModelState.IsValid)
      {
        if (MulticriteriaAnalisysService.CriteriaValue_SaveData(model))
        {
          return RedirectToAction("CriteriaValues", new { _CriteriaID = model.CriteriaId });
        }
      }

      return View("EditCriteriaValues", model);
    }
    public IActionResult EditCriteriaValue(int id)
    {
      var model = MulticriteriaAnalisysService.CriteriaValue_GetByID(id);
      SetViewBag(model);
      ViewBag.CriteriaValue = model.Name;
      return View("EditCriteriaValues", model);
    }
    [HttpPost]
    public IActionResult EditCriteriaValue(CriteriaValue model)
    {
      if (ModelState.IsValid)
      {
        if (MulticriteriaAnalisysService.CriteriaValue_SaveData(model))
        {
          return RedirectToAction("CriteriaValues", new { _CriteriaID = model.CriteriaId });
        }
      }
      SetViewBag(model);
      return View("EditCriteriaValue", model);
    }





































    private void SetViewBag(Criteria model)
        {

        }

    private void SetViewBag(CriteriaValue model)
    {

    }

  }
}