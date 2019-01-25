using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using WebCommmon.Controllers;

namespace Domain.Controllers
{
    public class BasePortalController : BaseController
    {
        public void MakeSourceItemVMPortal(int sourceType, int sourceId)
        {
            var model = new SourceItemVM()
            {
                SourceType = sourceType,
                SourceId = sourceId
            };

            switch (model.SourceType)
            {
                case GlobalConstants.SourceTypes.PublicConsultation:
                    model.BackUrl = Url.Action("View", "PublicConsultation", new { area = "", id = model.SourceId });
                    model.SourceTypeName = "Обществена консултация";
                    break;
                case GlobalConstants.SourceTypes.ChangeProposals:

                    model.BackUrl = Url.Action("ViewChangeProposals", "ChangeProposals", new { area = "", id = model.SourceId });
                    model.SourceTypeName = "Законодателна инициатива";
                    break;
            }

            ViewBag.sourceItem = model;
        }
    }
}
