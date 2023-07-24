
using BussinesLogic.IService;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lost_and_found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService userService;
        ILogger<UserController> _ilogger;
        public UserController(IUserService userService, ILogger<UserController> _ilogger)
        {
            this.userService = userService;
            this._ilogger = _ilogger;
        }
        [HttpGet]
        [Route("Get_user")]
        public async Task<ActionResult<UserDTO>> GetUser(string email, string password)
        {
            try
            {
            UserDTO user= await userService.GetUser(email, password);
            if (user != null)
            {
                return Ok(user);
            }
            else
                return NotFound();
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }


        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser(UserDTO userDTO)
        {
            try
            {
            UserDTO user = await userService.AddUser(userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            else
                return NotFound();
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }


        }
        [HttpPut]
        [Route("EditUser")]
        public async Task<ActionResult<UserDTO>> EditUser(UserDTO userDTO,   int id)
        {
            try
            {
                userDTO.UserId = id;
           UserDTO ud= await userService.EditUser(userDTO,id);
            if (ud != null)
            {
                return Ok(userDTO);
            }
            else
                return NotFound();
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }


        }


    }
}
