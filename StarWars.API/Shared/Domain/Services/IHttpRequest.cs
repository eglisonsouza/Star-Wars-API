using System.Net.Http;
using System.Threading.Tasks;

namespace StarWars.API.Shared.Domain.Services
{
    public interface IHttpRequest
    {
        Task<TValue> HttpGet<TValue>(string uri);
    }

}