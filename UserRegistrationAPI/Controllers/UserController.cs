using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Services;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices ius;
        public UserController(IUserServices _ius)
        {
            ius = _ius;
        }

        [HttpGet("AllUsers")]
        public IActionResult Gets()
        {
            return Ok(ius.GetAllUsers());
        }

        [HttpGet("GetsUser")]
        public IActionResult Get(string id)
        {
            return Ok(ius.GetUserById(id));
        }


        [HttpPost("Register")]
        public Task<User> Create(User user)
        {
            ius.AddUser(user);
            return Task.FromResult(user);
        }

        [HttpGet("login")]
        public IActionResult Login(string UserName, string Password)
        {

            return Ok(ius.Login(UserName, Password));
        }

        [HttpPut("UpdateUser")]
        public Task<User> Update(User user)
        {

            ius.UpdateUser(user);



            return Task.FromResult(user);
        }



        [HttpDelete("DeleteUser")]
        public IActionResult Delete(string id)
        {

            ius.DeleteUser(id);
            return Ok("User has been deleted");
        }
    }
}
