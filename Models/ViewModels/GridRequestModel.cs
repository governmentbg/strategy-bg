using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class GridRequestModel
    {
        public int page { get; set; }
        public int size { get; set; }
        public string filter { get; set; }
        public dynamic param { get; set; }
    }
}
