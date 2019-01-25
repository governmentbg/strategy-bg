using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context;
using Models.ViewModels.Consultations;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
    public interface IMigrationService
    {
    bool UploadFilesystemInCDN(Files legacyFile, string userFullNameCreated, int sourceID, int sourceType);
    bool MigrateAllFiles();
    bool MigrateImagesFromfolder(string mainFolderPath);
    }
}
