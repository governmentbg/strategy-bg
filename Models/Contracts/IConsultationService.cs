using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context.Consultations;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Services;

namespace Models.Contracts
{
    public interface IConsultationService : IBaseService
    {
        IQueryable<ConsultationListViewModel> GetConsultations();
        IEnumerable<SelectListItem> GetTargetGroupsDDL();
        bool SaveConsultation(ConsultationViewModel model, int userId);
        ConsultationViewModel GetConsultation(int id);
        ConsultationViewModel GetConsultationByProject(int id);

    //CBorisoff
    IQueryable<PublicConsultationVM> Portal_List(int langId = GlobalConstants.LangBG, int? validMode = null, int? docType = null, bool activeOnly = true);
        IEnumerable<TimelineDocumentViewModel> Portal_GetDocumentsList(int id);
        IQueryable<CommentVM> Portal_GetComments(int id);

        //IEnumerable<ConsultationVersionVM> GetVersionsByConsultationId(int id);
        ConsultationDocumentVM GetConsultationDocument(int documentId);
        IEnumerable<DocumentLinkVM> Portal_GetDocmentFiles(int documentId);
        IEnumerable<CommentVM> Portal_GetDocumentComments(int documentId);
        IQueryable<DocumentListViewModel> GetDocumentList(int consultationId);
        IEnumerable<TimelineDocumentViewModel> GetDocumentVersions(int id);
        DocumentViewModel GetDocument(int documentId);
        bool SaveDocument(DocumentViewModel model, int userId);
        string GetConsultationTitle(int consultationId);
        IQueryable<VersionListViewModel> GetVersionList(int documentId);
        DocumentViewModel CreateVersion(int documentId);
        List<SelectListItem> GetSections(string content);
        List<SelectListItem> GetDocumentTypesDDL();
        //IEnumerable<ConsultationVersionVM> GetVersionsByVersionId(int versionId);

        int GetInstitutionTypeId(int userId);

        int GetConsultationCommentsCount(int consultationId);
        IQueryable<ConsultationsExportListVM> GetConsultationsListForExport();

        IQueryable<MSProgram> Program_Select(int langId, int type, string title);
        bool Program_SaveData(MSProgram model);
        IQueryable<MSProgramProject> ProgramProject_Select(int langId, int? programId, string title);
        MSProgramProject ProgramProject_GetById(int id);
        bool ProgramProject_SaveData(MSProgramProject model);
        List<SelectListItem> GetProjects(int actId, int userId);
    }
}
