using Entities.Models;

namespace Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string userId);
        void CreateUser(User user);
        bool UsernameExists(string username);
        User Authenticate(string username, string password);
    }
}
