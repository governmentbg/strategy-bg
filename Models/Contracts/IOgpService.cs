using Models.Context.Ogp;
using Models.ViewModels.Ogp;
using System.Linq;
using WebCommon.Models;
using WebCommon.Services;

namespace Models.Contracts
{
    public interface IOgpService : IBaseService
    {
        IQueryable<PlanItemVM> Element_Select(int? parentId, int? id = null);
        IQueryable<TextValueVM> ElementType_Combo();
        IQueryable<TextValueVM> NationalPlanStates_Combo();
        bool Element_SaveData(NationalPlanElements model);

        IQueryable<TextValueVM> NationalPlanSubElements_Combo(int planId);
        //-------- Estimations -------------------
        IQueryable<EstimationVM> Estimation_Select(int elementId, int? parentId,int? id = null);
        bool Estimation_SaveData(NationalPlanEstimations model);
        IQueryable<TextValueVM> EstimationType_Combo();

        IQueryable<PlanItemVM> SelectPlansForOgpMenu();

        //============ Portal ============================
        PlanVM Portal_GetElement(int id);
    }
}
