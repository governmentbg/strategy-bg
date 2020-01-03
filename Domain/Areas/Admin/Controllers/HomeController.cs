﻿using Elastic.Models.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    /// <summary>
    /// Начален екран
    /// </summary>
    [Area(nameof(Areas.Admin))]
    public class HomeController : BaseAdminController
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
