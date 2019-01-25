using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Account
{
    public class UserInCategoryVM
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        [Display(Name = "Група")]
        public int CategoryMasterId { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Display(Name = "Област")]
        public int DistrictId { get; set; }

        [Display(Name = "Община")]
        public int MunicipalityId { get; set; }
    }
}
