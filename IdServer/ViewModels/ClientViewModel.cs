using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Идентификатор на приложение")]
        public string ClientId { get; set; }

        [Display(Name = "Код на приложение")]
        public string ClientSecret { get; set; }

        [Display(Name = "Наименование на приложение")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string ClientName { get; set; }

        [Display(Name = "URL списък за login")]
        public string[] RedirectUris { get; set; }

        [Display(Name = "URL списък за logout")]
        public string[] PostLogoutRedirectUris { get; set; }

        public ClientViewModel()
        {
            RedirectUris = new List<string>().ToArray();
            PostLogoutRedirectUris = new List<string>().ToArray();
        }
    }
}
