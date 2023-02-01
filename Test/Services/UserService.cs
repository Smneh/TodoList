using Entities.Models;
using Interface;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Entities.Models;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;

        public UserService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repo.User.GetAllUsers();
        }

        public User GetUserById(string id)
        {
            return _repo.User.GetUserById(id);
        }

        public AuthenticatedResponse CreateUser(SingUpUserDto userDto) {
            bool exist = _repo.User.UsernameExists(userDto.Username);
            if (exist)
                throw new DuplicateNameException();

            var user = new User(userDto.Name,userDto.Username, userDto.Password);
            _repo.User.CreateUser(user);
            _repo.Save();

            return this.GetJwtToken(user.Id, user.Username);
        }

        public AuthenticatedResponse Authenticate(LoginUserDto userDto)
        {
            var user = _repo.User.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
                return null;

            return this.GetJwtToken(user.Id, user.Username);
        }
        public AuthenticatedResponse GetJwtToken(string userId, string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKeyMew98sad123%&Fsad"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(5),
                SigningCredentials = signinCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return new AuthenticatedResponse { Token = tokenString };
        }

    }
}
