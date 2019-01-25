using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebCommon.Services
{
    public interface IBaseService
    {
        T Find<T>(object id) where T : class;
        DbSet<T> All<T>() where T : class;
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;
        bool DeleteRange<T>(Expression<Func<T, bool>> whatToDelete) where T : class;
    }
}
