using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("todos")]
    public class Todo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public Todo(string title, bool isCompleted , string userId)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            IsCompleted = isCompleted;
            UserId = userId;
        }

        public Todo(string id, string title, bool isCompleted, string userId)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
            UserId = userId;
        }
    }
}