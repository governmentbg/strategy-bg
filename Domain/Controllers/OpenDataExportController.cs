using CsvHelper;
using Domain.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Consultations;
using Models.ViewModels.PCSubjectsModels;
using Models.ViewModels.Portal;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;


namespace Domain.Controllers
{
    public class OpenDataExportController : BasePortalController
  {
        private readonly IStrategicDocumentsService StrategicDocumentsService;
        private readonly IPCSubjectsService PCSubjectsService;
        private readonly IHostingEnvironment environment;
        private readonly ICommentService commentService;
        private readonly IConsultationService consultationService;

    public OpenDataExportController(IConsultationService _consultationService, IPCSubjectsService _PCSubjectsService, IStrategicDocumentsService _strategicDocumentsService, IHostingEnvironment _environment, ICommentService _commentService)
        {
            StrategicDocumentsService = _strategicDocumentsService;
            PCSubjectsService = _PCSubjectsService;
            environment = _environment;
            commentService = _commentService;
            consultationService = _consultationService;
    }

    private MemoryStream Comments_GetExportData()
    {

      IQueryable<CommentsExportListVM> model = commentService.GetCommentsListForExport();

      
      var mem = new MemoryStream();
      var writer = new StreamWriter(mem, Encoding.UTF8);
      var csvWriter = new CsvWriter(writer);

      csvWriter.Configuration.Delimiter = "\t";

      csvWriter.Configuration.HasHeaderRecord = true;
      csvWriter.Configuration.AllowComments = true;
      csvWriter.Configuration.AutoMap<CommentsExportListVM>();

      csvWriter.WriteHeader<CommentsExportListVM>();
      csvWriter.NextRecord();
      csvWriter.WriteRecords(model);

      writer.Flush();
      mem.Position = 0;

      return mem;
    }

    [HttpGet]
    [Description("CSV експорт на Коментари")]
    public ActionResult CommentsCSVExport()
    {
      return new FileStreamResult(Comments_GetExportData(), "text/csv") { FileDownloadName = "Справка_Коментари.csv" };
    }

    public string CommentsCSVFileExport()
    {
      if (Request.IsLocal())
      {
        var folder = new System.IO.DirectoryInfo(environment.WebRootPath).Parent.FullName;
        var filePath = Path.Combine(folder, $"OpenDataExports\\CommentsCSVExport.csv");
        try
        {
          using (FileStream fs = System.IO.File.Create(filePath))
          {
            fs.Write(Comments_GetExportData().GetBuffer());
          }
        }
        catch (System.Exception)
        {

          throw;
        }
        return filePath;
      }
      return null;

    }

    private MemoryStream StrategicDocuments_GetExportData()
    {
      IQueryable<StrategicDocumensListVM> model = StrategicDocumentsService.StrategicDocumentsGetExport();

      var mem = new MemoryStream();
      var writer = new StreamWriter(mem, Encoding.UTF8);
      var csvWriter = new CsvWriter(writer);

      csvWriter.Configuration.Delimiter = "\t";

      csvWriter.Configuration.HasHeaderRecord = true;
      csvWriter.Configuration.AllowComments = true;
      csvWriter.Configuration.AutoMap<StrategicDocumensListVM>();

      csvWriter.WriteHeader<StrategicDocumensListVM>();
      csvWriter.NextRecord();
      csvWriter.WriteRecords(model);

      writer.Flush();
      mem.Position = 0;

      return mem;
    }

    public string StrategicDocumentsCSVFileExport()
    {
      if (Request.IsLocal())
      {
        var folder = new System.IO.DirectoryInfo(environment.WebRootPath).Parent.FullName;
        var filePath = Path.Combine(folder, $"OpenDataExports\\StrategicDocumentsCSVExport.csv");
        try
        {
          using (FileStream fs = System.IO.File.Create(filePath))
          {
            fs.Write(StrategicDocuments_GetExportData().GetBuffer());
          }
        }
        catch (System.Exception)
        {

          throw;
        }
        return filePath;
      }
      return null;

    }

    [HttpGet]
    [Description("CSV експорт на Стратегически документи")]
    public ActionResult StrategicDocumentsCSVExport()
    {
      return new FileStreamResult(StrategicDocuments_GetExportData(), "text/csv") { FileDownloadName = "Справка_Стратегически_документи.csv" };
    }


    private MemoryStream PCSubjects_GetExportData()
    {
      IQueryable<PCSubjectsExportListViewModel> model = PCSubjectsService.GetPCSubjectsGetExport();
      var mem = new MemoryStream();
      var writer = new StreamWriter(mem, Encoding.UTF8);
      var csvWriter = new CsvWriter(writer);
      csvWriter.Configuration.Delimiter = "\t";
      csvWriter.Configuration.HasHeaderRecord = true;
      csvWriter.Configuration.AllowComments = true;
      csvWriter.Configuration.AutoMap<PCSubjectsExportListViewModel>();
      csvWriter.WriteHeader<PCSubjectsExportListViewModel>();
      csvWriter.NextRecord();
      csvWriter.WriteRecords(model);
      writer.Flush();
      mem.Position = 0;
      return mem;
    }

    public string PCSubjectsCSVFileExport()
    {
      if (Request.IsLocal())
      {
        var folder = new System.IO.DirectoryInfo(environment.WebRootPath).Parent.FullName;
        var filePath = Path.Combine(folder, $"OpenDataExports\\PCSubjectsCSVExport.csv");
        try
        {
          using (FileStream fs = System.IO.File.Create(filePath))
          {
            fs.Write(PCSubjects_GetExportData().GetBuffer());
          }
        }
        catch (System.Exception)
        {

          throw;
        }
        return filePath;
      }
      return null;
    }

    [HttpGet]
    [Description("CSV експорт на лицата по ЗНА")]
    public ActionResult PCSubjectsCSVExport(int questionaryHeaderId, int? userId, string userEmail)
    {
   
      return new FileStreamResult(PCSubjects_GetExportData(), "text/csv") { FileDownloadName = "Справка_Лицат_по_ЗНА.csv" };
    }


    private MemoryStream Consultations_GetExportData()
    {

      IQueryable<ConsultationsExportListVM> model = consultationService.GetConsultationsListForExport();


      var mem = new MemoryStream();
      var writer = new StreamWriter(mem, Encoding.UTF8);
      var csvWriter = new CsvWriter(writer);

      csvWriter.Configuration.Delimiter = "\t";

      csvWriter.Configuration.HasHeaderRecord = true;
      csvWriter.Configuration.AllowComments = true;
      csvWriter.Configuration.AutoMap<ConsultationsExportListVM>();

      csvWriter.WriteHeader<ConsultationsExportListVM>();
      csvWriter.NextRecord();
      csvWriter.WriteRecords(model);

      writer.Flush();
      mem.Position = 0;

      return mem;
    }

    [HttpGet]
    [Description("CSV експорт на Консултации")]
    public ActionResult ConsultationsCSVExport()
    {
      return new FileStreamResult(Consultations_GetExportData(), "text/csv") { FileDownloadName = "Справка_Консултации.csv" };
    }

    public string ConsultationsCSVFileExport()
    {
      if (Request.IsLocal())
      {
        var folder = new System.IO.DirectoryInfo(environment.WebRootPath).Parent.FullName;
        var filePath = Path.Combine(folder, $"OpenDataExports\\ConsultationssCSVExport.csv");
        try
        {
          using (FileStream fs = System.IO.File.Create(filePath))
          {
            fs.Write(Consultations_GetExportData().GetBuffer());
          }
        }
        catch (System.Exception)
        {

          throw;
        }
        return filePath;
      }
      return null;

    }
  }
}