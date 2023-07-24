using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string email, string password);
        public Task<User> AddUser(User user);
        public Task<User> EditUser(User user);

    }
}
