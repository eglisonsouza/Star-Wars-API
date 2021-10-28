using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StarWars.API.Shared.Domain.Services;

namespace StarWars.API.Shared.Infra.Services
{
    public class HttpRequest : IHttpRequest
    {
        public async Task<TValue> HttpGet<TValue>(string uri)
        {
            return await new HttpClient().GetFromJsonAsync<TValue>(uri);
        }
    }
}