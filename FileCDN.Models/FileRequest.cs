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
        public string SourceID
        {
            get; set;
        }
        public string FileName
        {
            get; set;
        }
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage ="Въведете '{0}'.")]
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

        public string JScallback { get; set; }

    }
}
