using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Data
{
    public class DatabaseFactory : IDisposable, IDatabaseFactory
    {

        private DbContext _dataContext;

        public DbContext Get()
        {
            return _dataContext ?? (_dataContext = new Context());
        }

        void IDisposable.Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }

    public interface IDatabaseFactory : IDisposable
    {
        DbContext Get();
    }
}