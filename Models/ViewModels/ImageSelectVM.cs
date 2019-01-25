using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
{
    public class ImageSelectVM
    {
        public string FileId { get; set; }
        public string JScallback { get; set; }

        [Display(Name = "Максимална големина")]
        public int? Max { get; set; }

        [Display(Name = "Позиция")]
        public int Position { get; set; }

        [Display(Name = "Отместване от текста")]
        public int Margin { get; set; }
    }
}
