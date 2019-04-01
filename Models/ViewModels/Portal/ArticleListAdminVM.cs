using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class ArticleListAdminVM : ArticleListVM
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }

        public string Lang { get
            {
                switch (this.LanguageId)
                {
                    case GlobalConstants.LangEN:
                        return GlobalConstants.TextLangEN;
                    default:
                        return GlobalConstants.DefaultLang;
                }
            } }
    }
}
