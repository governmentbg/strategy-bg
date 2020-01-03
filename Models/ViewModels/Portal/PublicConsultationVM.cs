using Models.Contracts;
using Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class PublicConsultationVM : ICategorySearchableItem, IRssItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public string CategoryText { get; set; }
        public string CategoryImagePath { get; set; }
        public string TargetGroup { get; set; }
        public DateTime OpenningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int CategoryParentId { get; set; }
        public int CategorySectionId { get; set; }
        public bool IsActive { get; set; }
        public int ActiveDays
        {
            get
            {
                int days = 0;

                if (OpenningDate.Date <= DateTime.Today && ClosingDate.Date > DateTime.Today)
                {
                    days = (ClosingDate.Date - DateTime.Today).Days;
                }

                return days;
            }
        }
        public int CommentsCount { get; set; }
        public string Description { get; set; }
        public string Category { get => CategoryText; set => throw new NotImplementedException(); }
        public DateTime PublishDate { get => OpenningDate; set => throw new NotImplementedException(); }
    }
}
