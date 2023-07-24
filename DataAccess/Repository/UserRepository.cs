using DataAccess.DBModels;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        LfDBContext dBContext;
        public UserRepository(LfDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<User> GetUser(string email, string password)
        {
            var exitUser = await dBContext.Users.Where(e => e.Email == email && e.Password == password).ToListAsync();
            if (exitUser.Count == 1)
                return exitUser[0];
            return null;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                List<User> u = await dBContext.Users.Where(x => x.Email == user.Email).ToListAsync();
                if (u.Count == 0)
                {
                    dBContext.Users.Add(user);
                    await dBContext.SaveChangesAsync();
                    return user;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in add user function" + ex.Message);

            }


        }
        public async Task<User> EditUser(User user)
        {
            try
            {
                dBContext.Users.Update(user);
                await dBContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error in Edit_user function" + ex.Message);
                
            }



        }

    }
}
