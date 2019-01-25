using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCommon.Models;
using Models.Context;
using Models.Context.Application;
using Models.Contracts;

namespace Models.Services
{
    public class NomService : BaseService, INomService
    {
        public NomService(MainContext _db)
        {
            db = _db;
        }

        public IQueryable<TextValueVM> ActivityType_Select(string lang)
        {
            return All<ActivityType>(x => x.IsActive)
                    .ToList()
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = x.Code + ". " + ((lang == GlobalConstants.DefaultLang) ? x.NameBG : x.NameEN)
                    })
                    .OrderBy(x => x.Text)
                    .AsQueryable();
        }

        #region Counties
        public IQueryable<TextValueVM> Country_Select(string lang)
        {
            return All<Country>(x => x.IsActive)
                    .ToList()
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = (lang == GlobalConstants.DefaultLang) ? x.NameBG : x.NameEN
                    })
                    .OrderBy(x => x.Text)
                    .AsQueryable();
        }

        public IQueryable<Country> Country_Select()
        {
            return db.Countries.Where(x => x.Id != 0).AsQueryable();
        }

        public Country Country_GetByID(int id)
        {
            return db.Countries.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Country_SaveData(Country model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = db.Countries.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                    db.Countries.Update(model);
                    db.SaveChanges();
                }
                else
                {
                    db.Countries.Add(model);
                    db.SaveChanges();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<TextValueVM> CountryType_Combo(int? parent = -1)
        {
            return db.CountryTypes.Where(x => x.IsActive)
                .ToList()
                .Select(x => new TextValueVM
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).AsQueryable();

        }

        public IQueryable<TextValueVM> RiskCategory_Combo(int? parent = -1)
        {
            return db.CountryRiskCategories.Where(x => x.IsActive)
                .ToList()
                .Select(x => new TextValueVM
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).AsQueryable();

        }


        #endregion
        public IQueryable<TextValueVM> DocumentType_Select(string lang)
        {
            return All<DocumentType>(x => x.IsActive)
                   .ToList()
                   .Select(x => new TextValueVM
                   {
                       Value = x.Id.ToString(),
                       Text = (lang == GlobalConstants.DefaultLang) ? x.NameBG : x.NameEN
                   })
                   .OrderBy(x => x.Text)
                   .AsQueryable();
        }

        public IQueryable<TextValueVM> Ekkate_Select(string lang, string parentCode)
        {
            return All<Ekkate>(x => x.ParentCode == parentCode && x.IsActive)
                    .ToList()
                    .Select(x => new Ekkate
                    {
                        Code = x.Code,
                        NameBG = (lang == GlobalConstants.DefaultLang) ? x.NameBG : x.NameEN,
                        IsMain = x.IsMain
                    })
                    .OrderByDescending(x => x.IsMain)
                    .ThenBy(x => x.NameBG)
                    .Select(x => new TextValueVM
                    {
                        Value = x.Code,
                        Text = x.NameBG
                    })
                    .AsQueryable();
        }

        public IQueryable<TextValueVM> LocalEntityType_Select(string lang)
        {
            return All<LocalEntityType>(x => x.IsActive)
                    .ToList()
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = ((lang == GlobalConstants.DefaultLang) ? x.NameBG : x.NameEN)
                    })
                    .OrderBy(x => x.Text)
                    .AsQueryable();
        }
    }
}
