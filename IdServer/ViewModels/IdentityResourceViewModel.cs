using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class IdentityResourceViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Активен ресурс")]
        public bool Enabled { get; set; }
        [Display(Name = "Ключ")]
        [Required(ErrorMessage ="Въведете '{0}'")]
        public string Name { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string DisplayName { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Задължителен ресурс")]
        public bool Required { get; set; }
        [Display(Name = "Emphasize ресурс")]
        public bool Emphasize { get; set; }
        [Display(Name = "Покажи в документацията")]
        public bool ShowInDiscoveryDocument { get; set; }
    }
}
