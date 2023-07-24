using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.IService
{
    public interface IUserService
    {
        public Task<UserDTO> GetUser(string email, string password);
        public Task<UserDTO> AddUser(UserDTO user);
        public Task<UserDTO> EditUser(UserDTO userDTO,int id);
    }
}
