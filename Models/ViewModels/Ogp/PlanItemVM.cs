using WebCommon.Models;

namespace Models.ViewModels.Ogp
{
    public class PlanItemVM
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }

        public TextValueVM GetComboElement()
        {
            return new TextValueVM()
            {
                Value = this.Id.ToString(),
                Text = this.ElementTypeName + ": " + this.Title
            };
        }
    }
}
