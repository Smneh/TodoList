using Interface;
using Entities;
using Entities.Models;
using System.Data;
using Test.Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<User> GetUsers(UserParameters userParameters)
        {
            return PagedList<User>.ToPagedList(FindAll().OrderBy(on => on.Name),
                userParameters.PageNumber,
                userParameters.PageSize);
        }
        public User GetUserById(string userId)
        {
            return FindByCondition(user => user.Id.Equals(userId))
                    .FirstOrDefault();
        }
        public bool UsernameExists(string username)
        {
            return FindAll().Any(u => u.Username == username);
        }

        public User Authenticate(string username , string password) {
            return FindByCondition(user => user.Username ==username && user.Password == password).FirstOrDefault();
        }
        public void CreateUser(User user)
        {
                Create(user);
        }
    }
}