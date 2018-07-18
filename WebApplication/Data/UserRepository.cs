using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
        public User FindByUserName(string username)
        {
            try
            {
                return (User)_dbSet.Where(x => x.UserName == username).FirstOrDefault<User>();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
    }

}