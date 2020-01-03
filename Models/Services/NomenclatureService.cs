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
using Models.Context.Account;
using Models.Context.Consultations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebCommon.Services;
using static Models.GlobalConstants;

namespace Models.Services
{
    public class NomenclatureService : BaseService, INomenclatureService
    {

        private readonly IUserContext userContext;

        public NomenclatureService(MainContext _context, IUserContext _userContext)
        {
            db = _context;
            userContext = _userContext;
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


        private List<int> GetAllUserCategories()
        {

            var userId = this.userContext.UserId;
            int[] hasAccessTo = null;
            List<int> res = new List<int>();

            Expression<Func<Category, bool>> filter = x => true;
            Expression<Func<Category, bool>> Parentsfilter = x => true;

            hasAccessTo = this.All<UsersInGroups>(ug => ug.UserId == userId)
            .Select(ug => ug.Group.CategoryId ?? 0)
            .ToArray();
            filter = x => hasAccessTo.Contains(x.Id);

            res.AddRange(hasAccessTo);

            var section =
            this.All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted)
            .Where(filter)
            .ToDictionary(x => x.Id, x => x.SectionId);

            Func<int, IEnumerable<int>> getSection = null;
            getSection = i =>
                section.ContainsKey(i)
                    ? new[] { section[i] }.Concat(getSection(section[i]))
                    : Enumerable.Empty<int>();

            for (int i = 0; i < hasAccessTo.Length; i++)
            {
                res.AddRange(getSection(hasAccessTo[i]));
            }


            var parents =
            this.All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted)
            .Where(filter)
            .ToDictionary(x => x.Id, x => x.ParentId);

            Func<int, IEnumerable<int>> getParents = null;
            getParents = i =>
                parents.ContainsKey(i)
                    ? new[] { parents[i] }.Concat(getParents(parents[i]))
                    : Enumerable.Empty<int>();

            for (int i = 0; i < hasAccessTo.Length; i++)
            {
                res.AddRange(getParents(hasAccessTo[i]));
            }

            res = res.Distinct().ToList();

            int res_size = res.Count;
            int new_size = 0;

            while (new_size != res_size)
            {
                res_size = res.Count;
                filter = x => res.Contains(x.Id);

                parents =
                this.All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted)
                .Where(filter)
                .ToDictionary(x => x.Id, x => x.ParentId);


                for (int i = 0; i < res.Count; i++)
                {
                    res.AddRange(getParents(res[i]));
                }

                res = res.Distinct().ToList();
                new_size = res.Count;


            }
            return res;

        }

        public IEnumerable<TextValueVM> ComboCategories(int categoryId, int municipalityId = -1, bool isFromAdminPanel = false)
        {
            if (municipalityId == -1)
            {
                municipalityId = categoryId;
            }

            bool isAdmin = userContext.IsInRole(GlobalConstants.Roles.Admin);


            var allCat = All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted);


            Expression<Func<Category, bool>> filter = x => true;

            List<int> MyCats = GetAllUserCategories();

            if (isAdmin == false && isFromAdminPanel == true)
            {

                filter = x => MyCats.Contains(x.Id);
                allCat = All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted).Where(filter);
            }


            List<TextValueVM> result = new List<TextValueVM>();
            if (categoryId == 0)
            {
                if (isFromAdminPanel)
                {
                    if (MyCats.Contains(1)) { result.Add(new TextValueVM() { Text = "Национални", Value = GlobalConstants.Categories.Type_National.ToString() }); }
                    if (MyCats.Contains(2) || MyCats.Contains(3)) { result.Add(new TextValueVM() { Text = "Областни и общински", Value = GlobalConstants.Categories.Type_District.ToString() }); }
                    return result;
                }
                else
                {
                    result.Add(new TextValueVM() { Text = "Национални", Value = GlobalConstants.Categories.Type_National.ToString() });
                    result.Add(new TextValueVM() { Text = "Областни и общински", Value = GlobalConstants.Categories.Type_District.ToString() });
                    return result;
                }

            }

            if (categoryId == GlobalConstants.Categories.Type_National)
            {
                return allCat.Where(x => x.ParentId == categoryId)
                        .OrderBy(x => x.CategoryName)
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = x.CategoryName
                        });
            }


            if (categoryId == GlobalConstants.Categories.Type_District)
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
                case GlobalConstants.Categories.Type_National:
                    return data.Where(x => x.CategoryParentId == GlobalConstants.Categories.Type_National
                        && x.CategoryId == (catId.EmptyToNull() ?? x.CategoryId));
                default:
                    if (catId.EmptyToNull() == null)
                    {
                        return data.Where(x => (x.CategoryParentId == GlobalConstants.Categories.Type_District || x.CategoryParentId == GlobalConstants.Categories.Type_Municipal));
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
            }).ToList();
        }

        public List<SelectListItem> GetBaseCategories()
        {


            bool isAdmin = userContext.IsInRole(GlobalConstants.Roles.Admin);
            Expression<Func<Category, bool>> filter = x => true;
            List<int> MyCats = GetAllUserCategories();

            if (isAdmin == false)
            {

                filter = x => MyCats.Contains(x.Id);

            }


            var result = this.All<Category>(c => c.ParentId == 0)
                    .Where(c => c.LanguageId == GlobalConstants.LangBG)
                    .Where(c => c.IsActive && c.IsApproved)
                    .Where(filter)
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.CategoryName
                    }).ToList()
                    .Prepend(new SelectListItem()
                    {
                        Text = "Изберете",
                        Value = "-1"
                    }).ToList();

            return result;
        }

        public List<SelectListItem> GetCategoriesByParentId(int parentId, int userId, bool isAdmin)
        {
            if (parentId <= 0)
            {
                return GetEmptyList();
            }

            int[] hasAccessTo = null;

            if (isAdmin == false)
            {
                hasAccessTo = this.All<UsersInGroups>(ug => ug.UserId == userId)
                    .Select(ug => ug.Group.CategoryId ?? 0)
                    .ToArray();
            }

            var data = FilterCategories(parentId, hasAccessTo);

            return data
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                }).ToList()
                .Prepend(new SelectListItem()
                {
                    Text = "Изберете",
                    Value = "-1"
                }).ToList();
        }

        public List<SelectListItem> GetProgramsByType(int programType, int institutionId)
        {
            return this.All<MSProgramProject>()
                .Where(p => p.MSProgram.ProgramTypeId == programType)
                .Where(p => p.InstitutionTypeId == institutionId)
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Title
                }).ToList()
                .Prepend(new SelectListItem()
                {
                    Text = "Изберете",
                    Value = "-1"
                }).ToList();
        }

        public List<SelectListItem> GetEmptyList()
        {
            return new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Изберете",
                        Value = "-1"
                    }
                };
        }

        public List<SelectListItem> GetActDocumentTypes()
        {
            return this.All<DocumentType>(t => t.IsActive)
                .Select(t => new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Label
                }).ToList()
                .Prepend(new SelectListItem()
                {
                    Text = "Изберете",
                    Value = "-1"
                }).ToList();
        }

        private IEnumerable<Category> FilterCategories(int parentId, int[] hasAccessTo = null)
        {
            var data = this.All<Category>()
                .Where(x => x.ParentId == parentId)
                .Where(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted);

            if (hasAccessTo != null)
            {
                data = data.Where(d => hasAccessTo.Contains(d.Id));
            }

            return data.OrderBy(d => d.CategoryName);
        }

        public IQueryable<T> FilterByUserGroupRights<T>(IQueryable<T> data, int userId, bool isAdmin) where T : ICategorySearchableItem
        {
            int[] hasAccessTo = null;
            Expression<Func<T, bool>> filter = x => true;
            if (isAdmin == false)
            {
                hasAccessTo = this.All<UsersInGroups>(ug => ug.UserId == userId)
                    .Select(ug => ug.Group.CategoryId ?? 0)
                    .ToArray();

                filter = x => hasAccessTo.Contains(x.CategoryId);
            }
            return data.Where(filter);
        }

        public IEnumerable<SelectListItem> GetLinksCategoriesDDL_ByUser()
        {

            Expression<Func<LinksCategories, bool>> filter = x => true;
            if (!userContext.IsInRole(GlobalConstants.Roles.Admin))
            {
                int[] hasAccessTo = null;
                hasAccessTo = this.All<UsersInGroups>(ug => ug.UserId == userContext.UserId)
                    .Select(ug => ug.Group.LinksCategoryId ?? 0)
                    .Where(x => x > 0)
                    .ToArray();

                filter = x => hasAccessTo.Contains(x.Id);
            }

            var result = this.All<LinksCategories>()
                            .Where(g => g.LanguageId == GlobalConstants.LangBG)
                            .Where(filter)

                            .OrderBy(g => g.Name)
                            .Select(g => new SelectListItem()
                            {
                                Text = g.Name,
                                Value = g.Id.ToString()
                            })
                            .ToList();

            if (result.Count() > 1)
            {
                return result.Prepend(new SelectListItem()
                {
                    Text = "Изберете",
                    Value = "-1"
                }).ToList();
            }
            else
            {
                return result;
            }
        }
    }
}
