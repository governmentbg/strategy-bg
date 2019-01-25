using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class TranslationVM
    {
        public int ContentId { get; set; }
        public int PageId { get; set; }
        public string Lang { get; set; }
        public string LangName { get; set; }
        public string ItemUrl { get; set; }
    }
}
