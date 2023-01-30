using Entities.Models;


namespace Interface
{
    public interface ITodoRepository : IRepositoryBase<Todo>
    {
        //Todo GetUserTodos(string userId);
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(string todoId);
        IEnumerable<Todo> GetUserTodos(string userId);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
    }
}
