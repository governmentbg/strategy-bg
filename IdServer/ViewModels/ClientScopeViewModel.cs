using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class ClientScopeViewModel
    {
        public int ClientId { get; set; }

        public IEnumerable<ResourceScopeItem> ApiResourcesScopes { get; set; }
        public IEnumerable<ResourceScopeItem> IdentityResourcesScopes { get; set; }
    }

    public class ResourceScopeItem
    {
        public bool Checked { get; set; }
        public int ClientScopeId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Наименование")]
        public string DisplayName { get; set; }
    }
}
