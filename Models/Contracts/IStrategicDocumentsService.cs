using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context.Legacy;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using System;
using Models.Context;
using Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Models.Contracts
{
    public interface IStrategicDocumentsService
    {
        StrategicDocuments GetStrategicDocument(int id);
        //CBorisoff
        IQueryable<StrategicDocumentVM> Portal_List(int langId = GlobalConstants.LangBG, int? validMode = null);
        IQueryable<DocumentLinkVM> Portal_GetFileList(int id);
        StrategicDocumentPDFVM GetPDFModel(int mainCategoryId, DateTime? fromDate, DateTime? toDate, int langId = GlobalConstants.LangBG);
        bool StrategicDocuments_SaveData(StrategicDocuments model);
        List<BreadcrumbVM> GetBreadcrump(Category category, IUrlHelper urlHelper);
        //aAngelov
        IQueryable<StrategicDocumensListVM> StrategicDocumentsGetExport();
    }
}
