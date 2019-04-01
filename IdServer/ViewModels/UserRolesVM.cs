using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class UserRolesVM
    {
        public string UserId { get; set; }

        [Display(Name = "Имена")]
        public string FullName { get; set; }

        public List<ClientRolesVM> ClientRoles { get; set; }

        public UserRolesVM()
        {
            ClientRoles = new List<ClientRolesVM>();
        }
    }

    public class ClientRolesVM
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<CheckItemVM> Roles { get; set; }
    }
}
