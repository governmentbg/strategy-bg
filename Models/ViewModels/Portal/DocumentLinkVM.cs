using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class DocumentLinkVM
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public int SourceType { get; set; }
        public DateTime? DateExparing { get; set; }
        public bool? IsReportVisible { get; set; }

        public string AddInfo
        {
            get
            {
                string result = "";
                if (IsReportVisible == true)
                {
                    result += "Покажи в справката";
                }

                if (DateExparing.HasValue)
                    if (DateExparing.Value.Year > 2000 && DateExparing.Value.Year < 2100)
                    {
                        result += "| В сила до: " + DateExparing.Value.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        result += "| без указан срок";
                    }

                return result;
            }
        }

    }
}
