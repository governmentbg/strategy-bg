using System;

namespace FileCDN.Models
{
    public class FileSelect
    {
        public string FileId { get; set; }

        public int? SourceType
        {
            get; set;
        }
        public string SourceID
        {
            get; set;
        }

        public string SearchText { get; set; }
        public bool SingleFile { get; set; }

    }
}