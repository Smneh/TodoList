using Entities.Models;
using Test.Entities.Models;

namespace Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        AuthenticatedResponse CreateUser(SingUpUserDto userDto);
        AuthenticatedResponse Authenticate(LoginUserDto userDto);
    }
}
