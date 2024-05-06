namespace Cars.Services.Interface
{
    public interface IJwtService
    {
        string GetJwtToken(string userName,string role);
    }
}