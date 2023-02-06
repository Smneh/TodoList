using Interface;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Repository
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        public TodoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Todo> GetAllTodos()
        {
            return FindAll()
                .OrderBy(t => t.DateCreated)
                .ToList();
        }
        public Todo GetTodoById(string todoId)
        {
            return FindByCondition(todo => todo.Id.Equals(todoId))
                    .FirstOrDefault();
        }
        public IEnumerable<Todo> GetUserTodos(string userId)
        {
            return FindAll().Where(todo => todo.UserId == userId).OrderByDescending(t => t.DateCreated);
        }
        public void CreateTodo(Todo todo)
        {
            Create(todo);
        }
        
        public void UpdateTodo(Todo todo) 
        {
            Update(todo);
        }
        public void DeleteTodo (Todo todo) {
            Delete(todo);
        }
    }
}