using Models.Contracts;
using Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Consultations
{
  public class ConsultationsExportListVM : ICategorySearchableItem
  {

    public int Id { get; set; }
    public string Title { get; set; }
    public string URL { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int CategoryParentId { get; set; }
    public string CategoryParentName { get; set; }
    public int CategorySectionId { get; set; }
    public string CategorySectionName { get; set; }
    public int InstututionTypeId { get; set; }
    public string InstututionType { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentType { get; set; }
    public DateTime OpenningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime PublishDate { get => OpenningDate; set => throw new NotImplementedException(); }
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
    public string ShortTermReason { get; set; }


  }
}
