using Entities.Models;

namespace Interface
{
    public interface ITodoService
    {
        Todo GetTodoById(string id);
        IEnumerable<Todo> GetAllTodos();
        IEnumerable<Todo> GetUserTodos(string userId);
        int CreateTodo(TodoDto todoDto);
        int UpdateTodo(TodoDto todoDto);
        int DeleteTodo(string id);
    }
}
