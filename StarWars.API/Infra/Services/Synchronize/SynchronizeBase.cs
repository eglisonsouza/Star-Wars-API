using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;

namespace StarWars.API.Infra.Services.Synchronize
{
    public class SynchronizeBase
    {
        private readonly IHttpRequest _httpRequest;

        public SynchronizeBase(IHttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        protected async Task<List<T>> Synchronize<T>(string url)
        {
            ResultAPIViewModel<T> resultApi = null;
            List<T> objects = new List<T>();
            do
            {
                resultApi = await _httpRequest.HttpGet<ResultAPIViewModel<T>>(resultApi?.Next ?? url);
                objects.AddRange(resultApi.Results);
            } while (!String.IsNullOrEmpty(resultApi?.Next));

            return objects;
        }
    }
}