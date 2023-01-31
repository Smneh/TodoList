using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("users")]
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string name,string username, string password)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Username = username;
            Password = password;
        }
    }
}
