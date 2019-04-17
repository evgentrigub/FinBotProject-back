using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApi.Interfaces
{
    public interface IStorage
    {
        IStorage<T> GetStore<T>()
            where T : class;
        int SaveChanges();
    }

    public interface IStorage<T>
        where T : class
    {
        T Add(T model);
        IQueryable<T> Where(Expression<Func<T, bool>> e);
    }
}
