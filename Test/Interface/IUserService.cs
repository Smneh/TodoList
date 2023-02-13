using Entities.Models;
using Test.Entities.Models;

namespace Interface
{
    public interface IUserService
    {
        User GetUserById(string id);
        PagedList<User> GetUsers(UserParameters userParameters);
        AuthenticatedResponse CreateUser(SingUpUserDto userDto);
        AuthenticatedResponse Authenticate(LoginUserDto userDto);
    }
}
