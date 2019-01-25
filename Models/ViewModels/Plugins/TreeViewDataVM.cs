using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Plugins
{
    public class TreeViewDataVM
    {
        public string id { get; set; }
        public string position { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string lang { get; set; }
        public string icon { get; set; }
        public object li_attr { get; set; }
        public object a_attr { get; set; }
        public object t_attr { get; set; }
        public int ContentId { get; set; }
    }
}
