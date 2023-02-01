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

        public DateTime DateCreated { get; set; }

        public Todo(string title, string userId)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            IsCompleted = false;
            UserId = userId;
            DateCreated = DateTime.Now;
        }

        public Todo(string id, string title, bool isCompleted, string userId, DateTime dateCreated)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
            UserId = userId;
            DateCreated = dateCreated;
        }
    }
}