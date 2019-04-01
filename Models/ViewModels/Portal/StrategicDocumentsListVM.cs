using Models.Contracts;
using Models.Extensions;
using Models.ViewModels.Categories;
using System;

namespace Models.ViewModels.Portal
{
    public class StrategicDocumensListVM 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserCreated { get; set; }
        public string URL { get; set; }
        public string CategoryParent { get; set; }
        public string Category { get; set; }
        public string DocumentType { get; set; }
        public string Institution { get; set; }
        public string CreateDate { get; set; }
        public string ValidTo { get; set; }

    }
}
