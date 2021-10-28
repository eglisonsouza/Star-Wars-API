using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;

namespace StarWars.API.Infra.Services
{
    public class PlanetService : IPlanetService
    {
        private const string UrlPlanet = "https://swapi.dev/api/planets";

        private readonly IHttpRequest _httpRequest;

        public PlanetService(IHttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public async Task<List<PlanetViewModel>> Synchronize()
        {
            ResultAPIViewModel<PlanetViewModel> resultApi = null;
            List<PlanetViewModel> planets = new List<PlanetViewModel>();
            do
            {
                resultApi = await _httpRequest.HttpGet<ResultAPIViewModel<PlanetViewModel>>(resultApi?.Next ?? UrlPlanet);
                planets.AddRange(resultApi.Results);
            } while (!String.IsNullOrEmpty(resultApi?.Next));

            return planets;
        }
    }
}