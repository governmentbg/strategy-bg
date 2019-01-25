using System;

namespace FileCDN.Models
{
    public class FileInfo : FileRequest
    {
        public string Id { get; set; }
        public DateTime DateUploaded { get; set; }
        public string DateUploadedText
        {
            get
            {
                return this.DateUploaded.ToString("dd.MM.yyyy HH:mm");
            }
        }
        public bool IsActive { get; set; }
    }
}
