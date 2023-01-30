using Entities.Models;
using Interface;

namespace Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepositoryWrapper _repo;

        public TodoService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public IEnumerable<Todo> GetAllTodos()
        { 
            return _repo.Todo.GetAllTodos();
        }
        public Todo GetTodoById(string id) { 
            return _repo.Todo.GetTodoById(id); 
        }
        public int CreateTodo(TodoDto todoDto) {
            var user = _repo.User.GetUserById(todoDto.UserId);
            if (user is null)
                return 1;            
            var todo = new Todo(todoDto.Title, todoDto.IsCompleted, todoDto.UserId);
            _repo.Todo.CreateTodo(todo);
            _repo.Save();
            return 0;
        }
        public IEnumerable<Todo> GetUserTodos(string userId)
        {
            return _repo.Todo.GetUserTodos(userId);
        }
        public int UpdateTodo(TodoDto todoDto)
        {
            var todoEntity = _repo.Todo.GetTodoById(todoDto.Id);
            if (todoEntity is null)
                return 1 ;

            var todo = new Todo(todoDto.Id, todoDto.Title, todoDto.IsCompleted, todoDto.UserId);
            _repo.Todo.UpdateTodo(todo);
            _repo.Save();
            return 0;
        }

        public int DeleteTodo(string id) {

            var todoEntity = _repo.Todo.GetTodoById(id);
            if (todoEntity is null)
                return 1;
            _repo.Todo.DeleteTodo(todoEntity);
            _repo.Save();
            return 0;
        }
    }
}
