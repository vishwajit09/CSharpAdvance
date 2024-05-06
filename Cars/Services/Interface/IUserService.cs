using Cars.Dto;

namespace Cars.Services
{
    public interface IUserService
    {
        ResponseDto Signup(string username, string password);
        ResponseDto SignupAdmin(string username, string password);  
        ResponseDto Login(string username, string password);
        ResponseDto UpdateUserRole(string username, string roleName);
    }
}
