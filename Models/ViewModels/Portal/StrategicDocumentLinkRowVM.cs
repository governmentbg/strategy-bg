using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class StrategicDocumentLinkRowVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }

        public DateTime ValidTo { get; set; }

        public IEnumerable<StrategicDocumentLinkRowVM> Files { get; set; }

    }
}
