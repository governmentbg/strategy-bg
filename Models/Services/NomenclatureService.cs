using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using Models.Context.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Models;
using Models.ViewModels.Categories;
using WebCommon.Extensions;
using Models.Context.LinksModels;

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

        public IEnumerable<TextValueVM> ComboCategories(int categoryId, int municipalityId = -1)
        {
            if (municipalityId == -1)
            {
                municipalityId = categoryId;
            }

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
                            Text = x.CategoryName
                        })
                    );

                return result;
            }

            var currentDistrict = allCat.Where(x => x.Id == categoryId).FirstOrDefault();
            result.Add(new TextValueVM() { Value = currentDistrict.Id.ToString(), Text = "Всички" });
            result.AddRange(
                allCat.Where(x => x.SectionId == currentDistrict.Id)
                .OrderBy(x => x.CategoryName)
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = x.CategoryName
                    })
                );

            var selected = result.FirstOrDefault(x => x.Value == municipalityId.ToString());

            if (selected != null)
            {
                selected.Selected = true;
            }

            return result;
        }
        public IEnumerable<SelectListItem> GetInstitutionTypesDDL()
        {
            return this.All<InstitutionTypes>()
                .Where(g => g.LanguageId == 1)

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

        public IEnumerable<SelectListItem> GetLinksCategoriesDDL()
        {
            return this.All<LinksCategories>()
                .Where(g => g.LanguageId == GlobalConstants.LangBG)

                .OrderBy(g => g.Name)
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
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

        public IEnumerable<T> FilterByCategories<T>(IEnumerable<T> data, int catMasterId, int? catId, int? munId) where T : ICategorySearchableItem
        {
            switch (catMasterId)
            {
                case GlobalConstants.Category.Type_National:
                    return data.Where(x => x.CategoryParentId == GlobalConstants.Category.Type_National
                        && x.CategoryId == (catId.EmptyToNull() ?? x.CategoryId));
                default:
                    if (catId.EmptyToNull() == null)
                    {
                        return data.Where(x => (x.CategoryParentId == GlobalConstants.Category.Type_District || x.CategoryParentId == GlobalConstants.Category.Type_Municipal));
                    }
                    if (catId == munId)
                    {
                        return data.Where(x => (x.CategoryId == catId || x.CategorySectionId == catId));
                    }
                    return data.Where(x => x.CategoryId == munId);
            }
        }

        public List<SelectListItem> GetCategories()
        {
            var parentIds = this.All<Category>(c => c.ParentId > 0)
                .Where(c => c.LanguageId == GlobalConstants.LangBG)
                .Where(c => c.IsActive && c.IsApproved)
                .Select(c => c.ParentId)
                .Union(this.All<Category>(c => c.SectionId > 0).Select(c => c.SectionId))
                .Distinct()
                .OrderBy(c => c)
                .ToArray();

            var catIndex = this.All<Category>(c => parentIds.Contains(c.Id))
                .Where(c => c.LanguageId == GlobalConstants.LangBG)
                .ToDictionary(k => k.Id, v => new SelectListGroup() { Name = v.CategoryName });

            var categories = this.All<Category>()
                .Where(c => c.LanguageId == GlobalConstants.LangBG)
                .Where(c => c.IsActive && c.IsApproved)
                .Where(c => c.ParentId > 0)
                .OrderBy(c => c.ParentId)
                .ThenBy(c => c.CategoryName)
                .ToList();

            List<SelectListItem> result = new List<SelectListItem>();

            foreach (var category in categories)
            {
                result.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName,
                    Group = category.ParentId < 3 ? catIndex[category.ParentId] : catIndex[category.SectionId] 
                });
            }

            return result.Prepend(new SelectListItem()
            {
                Text = "Изберете",
                Value = "-1"
            }).ToList(); ;
        }
    }
}
