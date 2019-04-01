using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class ClaimViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ресурсна област")]
        public int ResourceId { get; set; }

        public string ResourceDisplayName { get; set; }
        [Display(Name = "Код на ресурс")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Type { get; set; }
    }
}
