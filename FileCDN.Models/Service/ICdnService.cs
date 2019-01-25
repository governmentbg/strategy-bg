using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileCDN.Models.Service
{
    public interface ICdnService<T> where T : DbContext
    {
        FileUploadResult Upload(FileRequest model);
        IEnumerable<FileInfo> Select(FileSelect model);
        FileInfo Download(FileSelect model);
        bool Disable(FileSelect model);
    }
}
