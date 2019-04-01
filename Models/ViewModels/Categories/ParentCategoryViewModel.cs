using Models.Context.Account;
using System.Collections.Generic;

namespace Models.ViewModels.CategoriesModels
{
  public class ParentCategoryViewModel
  {
    public ParentCategoryViewModel()
    {
      Categories = new List<CheckBoxListItem>();
    }

    public int Id { get; set; }

    public string CategoryName { get; set; }

    public List<CheckBoxListItem> Categories { get; set; }
  }
}
