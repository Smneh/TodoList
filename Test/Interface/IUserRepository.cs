using Entities.Models;
using Test.Entities.Models;

namespace Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        PagedList<User> GetUsers(UserParameters userParameters);
        User GetUserById(string userId);
        void CreateUser(User user);
        bool UsernameExists(string username);
        User Authenticate(string username, string password);
    }
}
