using Microsoft.AspNetCore.Mvc;
using WebCommon.Services;
using Models.Contracts;
using Models.ViewModels.MulticriteriaAnalysis;
using System;
using System.Linq;
using Models.Context.MulticriteriaAnalysis;
using System.Collections.Generic;
using WebCommon.Models;
using System.ComponentModel;
using Rotativa.AspNetCore;

namespace Domain.Controllers
{
  public class MulticriteriaAnalysisController : BasePortalController
    {
    private readonly IMulticriteriaAnalisysService MulticriteriaAnalisysService;
    private readonly IUserContext userContext;
    public MulticriteriaAnalysisController(IMulticriteriaAnalisysService _MulticriteriaAnalisysService, IUserContext _userContext)
    {
      MulticriteriaAnalisysService = _MulticriteriaAnalisysService;
      userContext = _userContext;
    }

    public IActionResult Index()
    {
      MulticriteriaAnalysisVM model = new MulticriteriaAnalysisVM();
      model = MulticriteriaAnalisysService.MulticriteriaAnalysis_Init();
      return View("Index", model);
    }

    [HttpPost]
    public IActionResult NewMCACalculation(MulticriteriaAnalysisVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      IQueryable<Criteria> _criteria = MulticriteriaAnalisysService.Criteria_Select();

      foreach (Criteria cr in _criteria.ToList())
      {
        mcaCriteriaVM _mcaCriteria = new mcaCriteriaVM();
        _mcaCriteria.CriteriaId = cr.Id;
        _mcaCriteria.CriteriaDescription = cr.Description;
        _mcaCriteria.CriteriaName = cr.Name;
        _mcaCriteria.CriteriaImpact = cr.Impact;
        _mcaCriteria.CriteriaTotalValue = 0;
        model.Criteria.Add(_mcaCriteria);
      }

      //for (int i = 0; i < 2; i++)
      //{
      //  mcaCriteriaVM criterion = new mcaCriteriaVM();
      //  model.Criteria.Add(criterion);
      //}
      return View("mcaCalculate", model);
    }

    [HttpPost]
    public IActionResult mcaCalculate(MulticriteriaAnalysisVM model)
    {

      model.TotalAssessmentValue = 0;
      try
      {
        foreach (mcaCriteriaVM criterion in model.Criteria)
        {
          Criteria _tmpCriteria = MulticriteriaAnalisysService.Criteria_GetByID(criterion.CriteriaId);
          criterion.CriteriaName = _tmpCriteria.Description;
          criterion.CriteriaDescription = _tmpCriteria.Name;
          criterion.CriteriaImpact = _tmpCriteria.Impact;
          criterion.CriteriaSelectedText = MulticriteriaAnalisysService.CriteriaValue_GetByID(criterion.CriteriaSelectedID).Name;
          criterion.CriteriaSelectedValue = MulticriteriaAnalisysService.CriteriaValue_GetByID(criterion.CriteriaSelectedID).Value;
          criterion.CriteriaTotalValue = (criterion.CriteriaImpact * criterion.CriteriaSelectedValue);

          model.TotalAssessmentValue += criterion.CriteriaTotalValue;
        }
      } catch {
        model = MulticriteriaAnalisysService.MulticriteriaAnalysis_Init();
        return View("Index", model);
      }

      return View("Index", model);
    }

    [HttpPost]
    [Description("Мултикритериен анализ на Административната тежест")]
    public IActionResult ExportCalculationToPDF(MulticriteriaAnalysisVM model)
    {
      return new ViewAsPdf("_CalculationPDF", model);
    }
  }
}