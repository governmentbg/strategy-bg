using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class CommentsRequestModel
    {
        public int SourceTypeId { get; set; }

        public int SourceId { get; set; }

        public List<SelectListItem> SectionList { get; set; }

        [Display(Name = "Към отметка")]
        public string PageTag { get; set; }

        public bool CanComment { get; set; }

        public string UpdateCommentsCallback { get; set; }

        public List<SelectListItem> UserIdentityList { get; set; }

        [Display(Name = "От името на")]
        public int UserIdentityId { get; set; }

        public CommentsRequestModel()
        {
            SectionList = new List<SelectListItem>() { new SelectListItem()  };
            UserIdentityList = new List<SelectListItem>() { new SelectListItem()  };
        }
    }
}
