using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Data;

namespace WebApplication.Data
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;

        protected readonly DbSet<TEntity> _dbSet;
        protected IDatabaseFactory DatabaseFactory { get; private set; }
        protected DbContext DataContext { get { return _context?? (_context = DatabaseFactory.Get()); } }

        public BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);       
        }
        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}