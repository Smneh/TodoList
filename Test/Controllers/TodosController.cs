using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Test.Controllers
{
    [Authorize]
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            try
            {
                var todos = _todoService.GetAllTodos();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "TodoById")]
        public IActionResult GetTodoById(string id)
        {
            try
            {
                var todo = _todoService.GetTodoById(id);
                if (todo is null)
                    return NotFound();
                else
                    return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getUserTodos")]
        public IActionResult GetUserTodos()
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var todos = _todoService.GetUserTodos(id);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTodo([FromBody] string todoTitle)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var response = _todoService.CreateTodo(todoTitle, userId);
                if (response is null)
                    return BadRequest(response);
                return Ok(response);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{todoId}")]
        public IActionResult UpdateTodo(string todoId, [FromBody] TodoDto todoDto) {
            try
            {
                var code = _todoService.UpdateTodo(todoDto,todoId);
                if (code == 1)
                    return BadRequest("UserId not found");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{todoId}")]
        public IActionResult DeleteTodo(string todoId) {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var code = _todoService.DeleteTodo(todoId, userId);
                if (code == 1)
                    return BadRequest("TodoId not found");
                if (code == 2)
                    return BadRequest("UserID dose not match the todo's userID");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

