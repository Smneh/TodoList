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

        public int CreateTodo(TodoDto todoDto, string userId) {
            var user = _repo.User.GetUserById(userId);
            if (user is null)
                return 1;            
            var todo = new Todo(todoDto.Title, todoDto.IsCompleted, userId);
            _repo.Todo.CreateTodo(todo);
            _repo.Save();
            return 0;
        }

        public IEnumerable<Todo> GetUserTodos(string userId)
        {
            return _repo.Todo.GetUserTodos(userId);
        }

        public int UpdateTodo(TodoDto todoDto, string todoId)
        {
            var todoEntity = _repo.Todo.GetTodoById(todoId);
            if (todoEntity is null)
                return 1 ;

            var todo = new Todo(todoEntity.Id, todoDto.Title, todoDto.IsCompleted, todoEntity.UserId);
            _repo.Todo.UpdateTodo(todo);
            _repo.Save();
            return 0;
        }

        public int DeleteTodo(string todoId, string userId) 
        {
            var todoEntity = _repo.Todo.GetTodoById(todoId);
            if (todoEntity is null)
                return 1;
            if (todoEntity.UserId != userId)
                return 2;
            _repo.Todo.DeleteTodo(todoEntity);
            _repo.Save();
            return 0;
        }
    }
}
