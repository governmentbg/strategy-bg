using System;
using System.Collections.Generic;
using System.Text;

namespace WebCommon.Models
{
    public class DashboardVM
    {
        public int Count { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Style { get; set; }
        public string Url { get; set; }

        public DashboardVM()
        {
            Style = "yellow";//жълто - bootstrap цветова тема
        }
    }
}
