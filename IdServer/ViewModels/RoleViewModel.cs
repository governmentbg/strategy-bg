using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class RoleViewModel
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name="Стойност")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Display(Name="Наименование")]
        public string DisplayName { get; set; }

        public string ClientId { get; set; }

    }
}
