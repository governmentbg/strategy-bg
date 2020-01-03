using System;

namespace Models.ViewModels.Portal
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public int prev_Id { get; set; }
        public int next_Id { get; set; }
        public int lang_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime LastModified { get; set; }
        public string MainImageFileId { get; set; }

        public bool IsActive { get; set; }
    }
}
