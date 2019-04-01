using Domain.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
  public class OpenDataExportSettings
  {
    public string OpenDataExportAPIEntryPoint { get; set; }
    public string OpenDataExportFolderPath { get; set; }

    public OpenDataExportSettings() { }
  }

  public class BackgroundOpenDataExportService : IHostedService
  {
    private Timer _timer;
    private readonly OpenDataExportSettings oDataExportConfig;


    public BackgroundOpenDataExportService(IOptions<OpenDataExportSettings> _OpenDataExportConfig)

    {
     oDataExportConfig = _OpenDataExportConfig.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      _timer = new Timer(BackgroundOpenDataExport, null, 0, GlobalConstants.OpenDataExportsGenerationPeriod * 3600 * 1000);
      return Task.CompletedTask;
    }

    void BackgroundOpenDataExport(object state)
    {
      System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
      System.Net.Http.HttpResponseMessage msg;
      //msg = client.GetAsync(oDataExportConfig.OpenDataExportAPIEntryPoint  + GlobalConstants.OpenDataStrategicDocumentsEntryPoint).Result;
      //msg = client.GetAsync(oDataExportConfig.OpenDataExportAPIEntryPoint  + GlobalConstants.OpenDataPCSubjectsEntryPoint).Result;
      //msg = client.GetAsync(oDataExportConfig.OpenDataExportAPIEntryPoint  + GlobalConstants.OpenDataCommentsEntryPoint).Result;
      //msg = client.GetAsync(oDataExportConfig.OpenDataExportAPIEntryPoint  + GlobalConstants.OpenDataConsultationsEntryPoint).Result;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _timer?.Change(Timeout.Infinite, 0);
      return Task.CompletedTask;
    }
  }
}
