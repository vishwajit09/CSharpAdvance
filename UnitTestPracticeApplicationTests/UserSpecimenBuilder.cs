using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnitTestPracticeApplication.Models;

namespace UnitTestPracticeApplicationTests
{
    public class UserSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(User))
            {
                CreatePasswordHash("Test", out byte[] passwordHash, out byte[] passwordSalt);
                return new User { Id = new Guid(), Username = "Vish", Password = passwordHash, PasswordSalt = passwordSalt };
            }
            return new NoSpecimen();
        }

        private static byte[] GenerateRandomByteArray(int length)
        {
            var random = new Random();
            var byteArray = new byte[length];
            random.NextBytes(byteArray);
            return byteArray;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
    }
}
