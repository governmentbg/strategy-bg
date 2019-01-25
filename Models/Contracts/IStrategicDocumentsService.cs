using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context.Legacy;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
  public interface IStrategicDocumentsService
  {
    StrategicDocuments GetStrategicDocument(int id);
    IQueryable<StrategicDocumentVM> Portal_List();
    IQueryable<DocumentLinkVM> Portal_GetFileList(int id);
    StrategicDocumentPDFVM GetPDFModel(int mainCategoryId);
    bool StrategicDocuments_SaveData(StrategicDocuments model);
  }
}
