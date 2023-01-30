using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult GetUserTodos([FromQuery] string id)
        {
            try
            {
                var todos = _todoService.GetUserTodos(id);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTodo([FromBody] TodoDto todoDto)
        {
            try
            {
                var code = _todoService.CreateTodo(todoDto);
                if (code == 1)
                    return BadRequest("UserId is not true");
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateTodo([FromBody] TodoDto todoDto) {
            try
            {
                var code = _todoService.UpdateTodo(todoDto);
                if (code == 1)
                    return BadRequest("UserId not found");

                return Ok("Todo Updated !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteTodo([FromBody] string todoId) {
            try
            {
                var code = _todoService.DeleteTodo(todoId);
                if (code == 1)
                    return BadRequest("TodoId not found");

                return Ok("Todo Deleted !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

