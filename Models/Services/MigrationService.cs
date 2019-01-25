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
  public class MigrationService : BaseService, IMigrationService
  {
    private readonly IUserContext userContext;
    private readonly ICdnService<MainContext> cdnService;



    public MigrationService(MainContext _db, IUserContext _userContext, ICdnService<MainContext> _cdnService)
    {
      db = _db;
      userContext = _userContext;
      cdnService = _cdnService;
    }


    private string GetFileRelativePath(Files file_item)
    {
      string path = null;

      //var folder_item = db.FileFolders.
      //  Join(db.Files, ff => ff.Id, f => f.FolderId, (ff, f) => new { ff, f }).Where(m => m.f.Id == FileID).FirstOrDefault();



      path = @"C:\SVN\Strategy\oldPortal\Uploads\Files\Folder_" + file_item.FolderId.ToString() + @"\" + file_item.Name.ToString().Trim();
      return path;
    }

    public bool UploadFilesystemInCDN(Files legacyFile, string userFullNameCreated, int sourceID, int sourceType)
    {
      bool result = false;
      try
      {


        using (FileStream fs = new FileStream(GetFileRelativePath(legacyFile), FileMode.Open))
        {
          byte[] fileContent = new byte[fs.Length];
          fs.Read(fileContent, 0, (int)fs.Length);


          FileCDN.Models.FileRequest model = new FileCDN.Models.FileRequest()
          {
            FileTitle = legacyFile.Description,
            FileName = legacyFile.Name,
            FileDescription = legacyFile.Id.ToString(),
            SourceType = sourceType,
            SourceID = sourceID.ToString(),
            UserUploaded = userFullNameCreated,
            FileContent = fileContent
          };

          var cdnresult = cdnService.Upload(model);
          result = cdnresult.SavedOK;
          if (result)
          {
            var usedFiles = db.Used_Files.Where(x => x.FileID == legacyFile.Id).ToList();
            foreach (var item in usedFiles)
            {
              db.FilesCDNUsed.Add(new FilesCDNUsed()
              {
                cdn_file_id = cdnresult.FileId,
                source_id = item.RecordID,
                source_type = item.TableType
              });
            }
            if (usedFiles.Count() > 0)
            {
              db.SaveChanges();
            }

          }
        }



        result = true;
      }
      catch (Exception ex)
      {


      }
      return result;
    }

    public bool MigrateAllFiles()
    {
      bool result = false;

      var users = db.Users.Select(x => new { Id = x.Id, Name = x.FullName }).ToList();
      int savedCount = 0;

      while ((db.Files.Where(x => x.ModifiedByUserId != 6666 && x.ModifiedByUserId != 7777).Count() > 0) && (savedCount < 1000))
      {
        result = true;
        savedCount++;
        var file_item = db.Files.Where(x => x.ModifiedByUserId != 6666 && x.ModifiedByUserId != 7777).OrderBy(x => x.Id).FirstOrDefault();
        //var used_files = db.Used_Files.Where(x => x.FileID == file_item.Id).FirstOrDefault();
        //int sourceId = used_files?.RecordID ?? -1;
        //int sourceType = used_files?.TableType ?? GlobalConstants.SourceTypes.Legacy_Unassigned;
        var userCreated = users.FirstOrDefault(x => x.Id == file_item.CreatedByUserId)?.Name;
        try
        {
          using (TransactionScope ts = new TransactionScope())
          {
            if (UploadFilesystemInCDN(file_item, userCreated, file_item.FolderId, GlobalConstants.SourceTypes.Library_Documents) == true)
            {
              file_item.ModifiedByUserId = 6666;
              db.SaveChanges();
            }
            else
            {
              file_item.ModifiedByUserId = 7777;
              db.SaveChanges();
            }
            ts.Complete();
          }
        }
        catch (Exception ex)
        {
          result = false;
          throw new Exception(string.Format("FileMigration: FileId : {0};error:", file_item.Id, ex.Message));
        }
      }

      return result;

    }
    public bool UploadFilesystemImageInCDN(FileInfo file, string userFullNameCreated, int sourceID, int sourceType)
    {
      bool result = false;
      try
      {
        

        using (FileStream fs = new FileStream(file.FullName, FileMode.Open))
        {
          byte[] fileContent = new byte[fs.Length];
          fs.Read(fileContent, 0, (int)fs.Length);


          FileCDN.Models.FileRequest model = new FileCDN.Models.FileRequest()
          {
            FileTitle = file.Name,
            FileName = file.Name,
            FileDescription = "",
            SourceType = sourceType,
            SourceID = sourceID.ToString(),
            UserUploaded = userFullNameCreated,
            FileContent = fileContent
          };

          //za Thumbneili
          //if (model.SourceType == GlobalConstants.SourceTypes.Library_Images)
          //{
          //  model.ThumbMaxSize = 150;
          //  model.ThumbSourceType = GlobalConstants.SourceTypes.Library_ImagesThumbs;
          //}
            //za Thumbneili
            var cdnresult = cdnService.Upload(model);
          result = cdnresult.SavedOK;



        }




        result = true;
      }
      catch (Exception ex)
      {


      }
      return result;
    }
    public bool MigrateImagesFromfolder(string mainFolderPath)
    {
      bool result = false;

    

      DirectoryInfo d = new DirectoryInfo(mainFolderPath+@"\News");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "", 105, 102);
      }

      d = new DirectoryInfo(mainFolderPath + @"\Articles");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "", 101, 102);
      }

      d = new DirectoryInfo(mainFolderPath + @"\Banners");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "", 102, 102);
      }



      d = new DirectoryInfo(mainFolderPath + @"\Categories");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "",103, 102);
      }

      d = new DirectoryInfo(mainFolderPath + @"\Facebook");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "",104, 102);
      }
      d = new DirectoryInfo(mainFolderPath + @"\Publications");

      foreach (var file in d.GetFiles())
      {
        UploadFilesystemImageInCDN(file, "",106, 102);
      }
      return result;
    }
  }
}
