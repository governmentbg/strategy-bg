using Models.Contracts;
using Models.Extensions;
using Models.ViewModels.Categories;
using System;

namespace Models.ViewModels.Portal
{
    public class StrategicDocumentVM : ICategorySearchableItem, IRssItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public int CategoryParentId { get; set; }
        public int CategorySectionId { get; set; }
        public string CategoryText { get; set; }
        public string CategoryImagePath { get; set; }
        public string TargetGroup { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime ValidTo { get; set; }
        public string ValidToText
        {
            get
            {
                return ValidTo.ValidToText();
            }
        }
        public DateTime ClosingDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get => Summary; set => throw new NotImplementedException(); }
        public string Category { get => CategoryText; set => throw new NotImplementedException(); }
        public DateTime PublishDate { get => CreateDate; set => throw new NotImplementedException(); }
        public bool IsActive { get; set; }
    }
}
