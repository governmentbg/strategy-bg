using Models.Context.Legacy;
using Models.ViewModels.Portal;
using System.Linq;
using System;
using WebCommon.Services;
using WebCommon.Models;
using System.Collections.Generic;
using Models.Context.MulticriteriaAnalysis;
using Models.ViewModels.MulticriteriaAnalysis;

namespace Models.Contracts
{
    public interface IMulticriteriaAnalisysService : IBaseService
    {
        Criteria Criteria_GetByID(int id);
        bool Criteria_SaveData(Criteria model);
        IQueryable<Criteria> Criteria_Select();
        CriteriaValue CriteriaValue_GetByID(int id);
        bool CriteriaValue_SaveData(CriteriaValue model);
        IQueryable<CriteriaValue> CriteriaValue_Select(int criteria_id);
        MulticriteriaAnalysisVM MulticriteriaAnalysis_Init();
    }
}
