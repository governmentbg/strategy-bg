using FileCDN.Models.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Context.Account;
using Models.Contracts;
using Models.Extensions;
using Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using WebCommon.Extensions;
using WebCommon.Models;
using WebCommon.Services;



namespace Models.Services
{
  public class StaticPagesService : BaseService, IStaticPagesService
  {
    private readonly IUserContext userContext;
    private readonly ICdnService<MainContext> cdnService;



    public StaticPagesService(MainContext _db, IUserContext _userContext, ICdnService<MainContext> _cdnService)
    {
      db = _db;
      userContext = _userContext;
      cdnService = _cdnService;
    }


  }
}
