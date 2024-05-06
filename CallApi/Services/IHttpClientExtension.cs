using CallApi.Dtos;

namespace CallApi.Services
{
    public interface IHttpClientExtension
    {
        Task<List<CarDto>> GetListCarInformation();
    }
}