using Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Test.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] SingUpUserDto userDto)
        {
            try
            {
                _userService.CreateUser(userDto);
                return Ok("User created !");
            }
            catch(DuplicateNameException) {
                return BadRequest("Username already taken");
            }
            catch (Exception ex)
            {
                return StatusCode(500 , ex.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Authneticate([FromBody] LoginUserDto userDto)
        {
            try
            {
                var response = _userService.Authenticate(userDto);

                if (response == null)
                    return BadRequest("Username or password is incorrect !");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500 , ex.Message);
            }
        }
    }
}
