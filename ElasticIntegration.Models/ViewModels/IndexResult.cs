using System;
using System.Collections.Generic;
using System.Text;

namespace Elastic.Models.ViewModels
{
    public class IndexResult
    {
        public bool IsValid { get; set; }
        public string ErrorReason { get; set; }
        public Exception Exception { get; set; }
    }
}
