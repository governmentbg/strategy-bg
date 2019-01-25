using System;

namespace FileCDN.Models
{
    public class FileUploadResult 
    {
        public bool SavedOK { get; set; }
        public string FileId { get; set; }
        public string ErrorMessage { get; set; }
    }
}