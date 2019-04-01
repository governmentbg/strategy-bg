using Models.Contracts;
using System;

namespace Models.ViewModels.Portal
{
    public class ArticleListVM : IRssItem
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDateTXT { get { return EventDate.ToString("dd MMM yyyy г."); } }
        public DateTime LastModified { get; set; }
        public string MainImageFileId { get; set; }
        public bool? IsRss { get; set; }
        public string RssPostLink { get; set; }
        public string Description { get; set; }
        public string Category { get => CategoryName; set => throw new NotImplementedException(); }
        public DateTime PublishDate { get => EventDate; set => throw new NotImplementedException(); }
    }
}
