using Models.Context;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.CategoriesModels
{
  public class CategoryViewModel
  {
    public CategoryViewModel()
    {
      Priority = 0;
      IsDeleted = false;
      IsApproved = true;
      IsActive = true;
      LanguageId = 1;
      ParentId = 0;
      SectionId = 0;
      ImagePath = "";
    }
    public int Id { get; set; }

    [Display(Name = "Главна категория")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    public int ParentId { get; set; }

    [Display(Name = "Област")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    public int SectionId { get; set; }

    public string ImagePath { get; set; }

    [Display(Name = "Име")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
    public string CategoryName { get; set; }

    [Required(ErrorMessage = "Полето {0} е задължително")]
    [Display(Name = "Дата на създаване")]
    public DateTime DateCreated { get; set; }

    [Display(Name = "Активна")]
    public bool IsActive { get; set; }

    public int Priority { get; set; }

    [Display(Name = "Изтрита")]
    public bool IsDeleted { get; set; }

    [Display(Name = "Одобрена")]
    public bool IsApproved { get; set; }

    public int LanguageId { get; set; }

    public int CreatedByUserId { get; set; }

    public int ModifiedByUserId { get; set; }

    public DateTime DateModified { get; set; }

    public Category ToEntity(Category entity = null)
    {
      if (entity == null)
      {
        entity = new Category();
      }

      entity.Id = this.Id;
      entity.ParentId = this.ParentId;
      entity.SectionId = this.SectionId;
      entity.ImagePath = this.ImagePath;
      entity.CategoryName = this.CategoryName;

      entity.IsActive = this.IsActive;
      entity.IsDeleted = this.IsDeleted;
      entity.IsApproved = this.IsApproved;

      entity.DateCreated = this.DateCreated;
      entity.Priority = this.Priority;
      entity.LanguageId = this.LanguageId;
      entity.CreatedByUserId = this.CreatedByUserId;
      entity.ModifiedByUserId = this.ModifiedByUserId;
      entity.DateModified = this.DateModified;

      return entity;
    }

    public void FromEntity(Category entity)
    {
      Id = entity.Id;
      this.ParentId = entity.ParentId;
      this.SectionId = entity.SectionId;
      this.ImagePath = entity.ImagePath;

      CategoryName = entity.CategoryName;
      IsActive = entity.IsActive;
      DateCreated = entity.DateCreated;

      Priority = entity.Priority;
      IsDeleted = entity.IsDeleted;
      IsApproved = entity.IsApproved;
      LanguageId = entity.LanguageId;
      CreatedByUserId = entity.CreatedByUserId;
      ModifiedByUserId = entity.ModifiedByUserId;
      DateModified = entity.DateModified;
    }
  }


}
