using Models.Context.Account;
using Models.ViewModels.CategoriesModels;
using System.Collections.Generic;

namespace Models.ViewModels.Account
{
  public class UserInCategoriesVM
  {
    public UserInCategoriesVM()
    {
      ParentCategories = new List<ParentCategoryViewModel>();
    }

    public List<ParentCategoryViewModel> ParentCategories { get; set; }
  }
}
