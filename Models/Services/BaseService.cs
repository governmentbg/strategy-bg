using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebCommon.Services;
using Models.Context;

namespace Models.Services
{
    public abstract class BaseService : IBaseService
    {
        protected MainContext db;

        public DbSet<T> All<T>() where T : class
        {
            return db.Set<T>();
        }
        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return db.Set<T>().Where(search);
        }
        public bool DeleteRange<T>(Expression<Func<T, bool>> whatToDelete) where T : class
        {
            try
            {
                var setOfT = db.Set<T>();
                var forDelete = setOfT.Where(whatToDelete);
                setOfT.RemoveRange(forDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T Find<T>(object id) where T : class
        {
            return db.Set<T>().Find(id);
        }

       
    }
}
