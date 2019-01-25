using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Context;
using Models.Contracts;

namespace Models.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly MainContext db;
        public LibraryService(MainContext _db)
        {
            db = _db;
        }
        public IQueryable<Library> Select(int source_type, int? parent_id, string title)
        {
            return db.Libraries.Where(x => x.SourceType == source_type)
                 .Where(x => x.ParentId == (parent_id ?? x.ParentId))
                 .AsQueryable();
        }

        public Library GetByID(int id)
        {
            return db.Libraries.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Save(Library model)
        {

            try
            {
                if (model.Id > 0)
                {
                    var saved = db.Libraries.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                    model.DateCreated = saved.DateCreated;

                    db.Libraries.Update(model);
                    db.SaveChanges();
                }
                else
                {
                    model.DateCreated = DateTime.Now;
                    db.Libraries.Add(model);
                    db.SaveChanges();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
