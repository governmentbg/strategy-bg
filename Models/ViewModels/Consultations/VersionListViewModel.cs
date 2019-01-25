using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Consultations
{
    public class VersionListViewModel
    {
        public int Id { get; set; }

        public int Revision { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
