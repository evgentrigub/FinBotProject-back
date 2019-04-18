//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using WebApi.Helpers;
//using WebApi.Interfaces;

//namespace WebApi.Services.Base
//{
//    public class Storage : IStorage
//    {
//        private DataContext _db = new DataContext();
//        public IStorage<T> GetStore<T>()
//            where T : class
//        {
//            return new Storage<T>(_db);
//        }

//        public int SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class Storage<T> : IStorage<T>
//            where T : class
//    {
//        private readonly DataContext db;
//        private readonly DbSet<T> _set;

//        public Storage(DataContext db)
//        {
//            this.db = db ?? throw new ArgumentNullException(nameof(db));
//            _set = db.Set<T>();
//        }

//        public T Add(T model)
//        {
//            return _set.Add(model);
//        }

//        public T Find<TKey>(TKey id)
//        {
//            return _set.Find(id);
//        }

//        public IQueryable<T> Where(Expression<Func<T, bool>> e)
//        {
//            return _set.Where(e);
//        }

//        public int SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}