using Entities.Models;
using Test.Entities.Models;

namespace Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        void CreateUser(UserDto userDto);
        AuthenticatedResponse Authenticate(UserDto userDto);
    }
}
