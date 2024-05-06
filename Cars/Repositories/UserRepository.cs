using System.Linq;
using Cars.Models;

namespace Cars.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDBContext _context;

        public UserRepository(CarDBContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User UpdateRole(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return _context.Users.SingleOrDefault(x => x.Username == user.Username);



        }
    }
}
