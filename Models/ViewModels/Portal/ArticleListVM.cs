using System;

namespace Models.ViewModels.Portal
{
    public class ArticleListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDateTXT { get { return EventDate.ToString("dd MMM yyyy г."); } }
        public DateTime LastModified { get; set; }
        public string MainImageFileId { get; set; }
        public bool? IsRss { get; set; }
        public string RssPostLink { get; set; }

    }
}
