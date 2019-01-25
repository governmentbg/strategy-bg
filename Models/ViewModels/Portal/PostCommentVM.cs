using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class PostCommentVM
    {
        public int SourceTypeId { get; set; }

        public int SourceId { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string Comment { get; set; }

        public string PageTag { get; set; }
    }
}
