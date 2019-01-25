using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using Models.Context.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Models;

namespace Models.Services
{
    public class NomenclatureService : BaseService, INomenclatureService
    {
        public NomenclatureService(MainContext _context)
        {
            db = _context;
        }

        public HierarchicalNomenclatureDisplayItem GetCategory(int id)
        {
            var result = new HierarchicalNomenclatureDisplayItem();
            var allCategories = this.All<Category>()
                .ToList();
            var categoryItem = allCategories.FirstOrDefault(a => a.Id == id);

            if (categoryItem != null)
            {
                string category = String.Empty;
                int rootId = 0;

                (category, rootId) = GetParentCategory(allCategories, categoryItem);

                result.Id = categoryItem.Id.ToString();
                result.Label = categoryItem.CategoryName;
                result.Category = category;
            }

            return result;
        }

        private (string, int) GetParentCategory(List<Category> allCategories, Category categoryItem)
        {
            string category = String.Empty;
            int rootId = 0;

            if (categoryItem.ParentId != 0)
            {
                var parent = allCategories.FirstOrDefault(p => p.Id == categoryItem.ParentId);

                if (parent != null)
                {
                    category = parent.CategoryName;
                    rootId = parent.Id;
                }
            }

            if (categoryItem.SectionId != 0)
            {
                var section = allCategories.FirstOrDefault(s => s.Id == categoryItem.SectionId);

                if (section != null)
                {
                    category += $", {section.CategoryName}";
                }
            }

            return (category, rootId);
        }

        public HierarchicalNomenclatureDisplayModel SearchCategory(string query)
        {
            query = query?.ToLower();

            var result = new HierarchicalNomenclatureDisplayModel();
            List<Category> allCategories = this.All<Category>()
                .ToList();

            var parents = allCategories
                .Select(a => a.ParentId)
                .Distinct()
                .ToArray();

            var categories = allCategories
                .Where(c => c.IsActive)
                .Where(c => c.IsApproved)
                .Where(c => !c.IsDeleted)
                .Where(c => c.LanguageId == GlobalConstants.Language.Bulgarian)
                .Where(c => !parents.Contains(c.Id))
                .Where(c => c.CategoryName.ToLower().Contains(query))
                .ToList();

            foreach (var item in categories)
            {
                string category = String.Empty;
                int rootId = 0;

                (category, rootId) = GetParentCategory(allCategories, item);

                result.Data.Add(new HierarchicalNomenclatureDisplayItem()
                {
                    Id = item.Id.ToString(),
                    Label = item.CategoryName,
                    Category = category,
                    RootId = rootId
                });
            }

            return result;
        }

        public IEnumerable<TextValueVM> ComboCategories(int categoryId)
        {
            var allCat = All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted).ToList();
            List<TextValueVM> result = new List<TextValueVM>();
            if (categoryId == 0)
            {
                result.Add(new TextValueVM() { Text = "Национални", Value = GlobalConstants.Category.Type_National.ToString() });
                result.Add(new TextValueVM() { Text = "Областни и общински", Value = GlobalConstants.Category.Type_District.ToString() });
                return result;
            }

            if (categoryId == GlobalConstants.Category.Type_National)
            {
                return allCat.Where(x => x.ParentId == categoryId)
                        .OrderBy(x => x.CategoryName)
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = x.CategoryName
                        });
            }


            if (categoryId == GlobalConstants.Category.Type_District)
            {
                result.AddRange(
                    allCat.Where(x => x.ParentId == categoryId)
                    .OrderBy(x => x.CategoryName)
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = "обл. " + x.CategoryName
                        })
                    );

                return result;
            }

            var currentDistrict = allCat.Where(x => x.Id == categoryId).FirstOrDefault();
            result.Add(new TextValueVM() { Value = currentDistrict.Id.ToString(), Text = "област " + currentDistrict.CategoryName.ToUpper() });
            result.AddRange(
                allCat.Where(x => x.SectionId == currentDistrict.Id)
                .OrderBy(x => x.CategoryName)
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = "общ. " + x.CategoryName
                    })
                );

            return result;
        }
    public IEnumerable<SelectListItem> GetInstitutionTypesDDL()
    {
      return this.All<InstitutionTypes>()
          .Where(g => g.LanguageId==1)
      
          .OrderBy(g => g.InstitutionTypeName)
          .Select(g => new SelectListItem()
          {
            Text = g.InstitutionTypeName,
            Value = g.Id.ToString()
          })
          .ToList()
          .Prepend(new SelectListItem()
          {
            Text = "Изберете",
            Value = "-1"
          })
          .ToList();

    }
    public IEnumerable<SelectListItem> GetDocumentTypesDDL()
    {
      return this.All<StrategicDocumentTypes>()
          .Where(g => g.LanguageId == GlobalConstants.LangBG)

          .OrderBy(g => g.DocumentTypeName)
          .Select(g => new SelectListItem()
          {
            Text = g.DocumentTypeName,
            Value = g.Id.ToString()
          })
          .ToList()
          .Prepend(new SelectListItem()
          {
            Text = "Изберете",
            Value = "-1"
          })
          .ToList();

    }
  }
}
