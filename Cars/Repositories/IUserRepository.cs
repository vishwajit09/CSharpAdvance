using Cars.Models;

namespace Cars.Services.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SaveUser(User user);

        User UpdateRole(User user);
    }
}
