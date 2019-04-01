using System;
using System.ComponentModel.DataAnnotations;

namespace FileCDN.Models
{
    public class FileRequest
    {
        public int SourceType
        {
            get; set;
        }
        public int ThumbSourceType
        {
            get; set;
        }
        public int ThumbMaxSize
        {
            get; set;
        }
        [Display(Name = "Документна библиотека")]
        public string SourceID
        {
            get; set;
        }
        public string FileName
        {
            get; set;
        }
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Въведете '{0}'.")]
        public string FileTitle
        {
            get; set;
        }
        public string FileDescription
        {
            get; set;
        }
        public byte[] FileContent
        {
            get; set;
        }
        public string ContentType { get; set; }

        public string UserUploaded
        {
            get; set;
        }
        [Display(Name = "В сила до")]
        public DateTime? DateExparing { get; set; }

        [Display(Name = "Покажи в справката")]
        public bool? IsReportVisible { get; set; }

        public int UsedFilesSourceType { get; set; }

        public string JScallback { get; set; }
        public string DirectUploadMethod { get; set; }

    }
}
