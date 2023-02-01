using Entities.Models;

namespace Interface
{
    public interface ITodoService
    {
        Todo GetTodoById(string id);
        IEnumerable<Todo> GetAllTodos();
        IEnumerable<Todo> GetUserTodos(string userId);
        Todo CreateTodo(string todoTitle, string userId);
        int UpdateTodo(TodoDto todoDto, string todoId);
        int DeleteTodo(string todoId, string userId);
    }
}
