using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Consultations;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class MigrationController : BaseController
    {
        private readonly IMigrationService migrationonService;

        public MigrationController(IMigrationService _migrationonService)
        {
            migrationonService = _migrationonService;
        }

        public IActionResult Index()
        {

      ////////////////////Osnovni fajlove
      //string batch = "";
      //DateTime dt = DateTime.Now;
      //int i = 0;
      //do
      //{
      //    i++;
      //    batch += string.Format("[Batch:{0}; Time:{1}]", i, DateTime.Now - dt);
      //    dt = DateTime.Now;
      //}
      //while (migrationonService.MigrateAllFiles());

      //return Content(batch.ToString());


      ////////////////////Osnovni fajlove
     bool mig=migrationonService.MigrateImagesFromfolder(@"C:\SVN\Strategy\oldPortal\Uploads\Images");
      return View();
    }


  }
}