using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        protected IDatabaseFactory DatabaseFactory { get; private set; }
        protected DbContext DataContext { get { return _context ?? (_context = DatabaseFactory.Get()); } }

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }

    public interface IUnitOfWork
    {
        void Commit();
    }
}
