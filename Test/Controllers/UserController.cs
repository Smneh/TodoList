using Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Test.Entities.Models;

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
                var response = _userService.CreateUser(userDto);
                return Ok(response);
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

        [HttpGet]
        public IActionResult GetOwners([FromQuery] UserParameters userParameters)
        {
            var users = _userService.GetUsers(userParameters);
            var metadata = new
            {
                users.TotalCount,
                users.PageSize,
                users.CurrentPage,
                users.TotalPages,
                users.HasNext,
                users.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(users);
        }
    }
}
