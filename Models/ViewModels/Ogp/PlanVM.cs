using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Ogp
{
    public class PlanVM
    {
        public PlanItemVM Plan { get; set; }
        public PlanItemVM Parent { get; set; }
        public IEnumerable<PlanItemVM> SubElements { get; set; }
    }
}
