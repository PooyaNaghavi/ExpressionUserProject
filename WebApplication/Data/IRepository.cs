
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Remove(TEntity entity);
        TEntity FindById(int id);
    }
}
