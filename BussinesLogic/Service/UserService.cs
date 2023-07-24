using AutoMapper;
using BussinesLogic.IService;
using DataAccess.DBModels;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Service
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository, IMapper _mapper)
        {
            this.userRepository = userRepository;
            this._mapper = _mapper;
        }
        public async Task<UserDTO> GetUser(string email, string password)
        {
            User user= await userRepository.GetUser(email, password);
            UserDTO ud = _mapper.Map<UserDTO>(user);
            return ud;
        }
        public async Task<UserDTO> AddUser(UserDTO user)
        {
            User u = _mapper.Map<User>(user);
            User user1= await userRepository.AddUser(u);
            UserDTO us = _mapper.Map<UserDTO>(user1);

            return us;
        }
        public async Task<UserDTO> EditUser(UserDTO userDTO,int id)
        {
            User user = _mapper.Map<User>(userDTO);
            user.UserId = id;
            User user1= await userRepository.EditUser(user);
            UserDTO us = _mapper.Map<UserDTO>(user1);
            return us;
        }
    }
}
