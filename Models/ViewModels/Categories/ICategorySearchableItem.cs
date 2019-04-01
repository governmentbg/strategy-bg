using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Categories
{
    public interface ICategorySearchableItem
    {
        int CategoryId { get; set; }
        int CategoryParentId { get; set; }
        int CategorySectionId { get; set; }
    }
}
