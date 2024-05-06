using System;
using System.Linq;
using System.Security.Cryptography;
using Cars.Dto;
using Cars.Models;
using Cars.Services.Repositories;

namespace Cars.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public ResponseDto Login(string username, string password)
        {
            var user = _repository.GetUser(username);
            if (user is null)
                return new ResponseDto(false, "Username or password does not match","");

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
                return new ResponseDto(false, "Username or password does not match", "");

            return new ResponseDto(true, "User logged in",user.Role);
        }

        public ResponseDto Signup(string username, string password)
        {
            var user = _repository.GetUser(username);
            if (user is not null)
                return new ResponseDto(false, "User already exists",user.Role);

            user = CreateUser(username, password,"User");
            _repository.SaveUser(user);
            return new ResponseDto(true);
        }

        private User CreateUser(string username, string password,string role)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role
            };

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }

        public ResponseDto SignupAdmin(string username, string password)
        {
            var user = _repository.GetUser(username);
            if (user is not null)
                return new ResponseDto(false, "User already exists", user.Role);

            user = CreateUser(username, password, "Admin");
            _repository.SaveUser(user);
            return new ResponseDto(true);
        }

        public ResponseDto UpdateUserRole(string username, string roleName)
        {
            var user = _repository.GetUser(username);
            if (user is  null)
                return new ResponseDto(false, "User does not exist", user.Role);
            if (user.Role != roleName)
            {
                user.Role = roleName;
                _repository.UpdateRole(user);
                return new ResponseDto(true);
            }
            else
            {
                return new ResponseDto(false,"Role already exist" ,user.Role);
            }
            
        }
    }
}
