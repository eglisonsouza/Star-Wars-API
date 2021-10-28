using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Infra.Services
{
    public class StarshipService: SynchronizeBase, IStarshipService
    {
        private const string UrlStarship = "https://swapi.dev/api/starships";

        public StarshipService(IHttpRequest httpRequest) : base(httpRequest)
        {
        }
        public async Task<List<StarshipViewModel>> Synchronize()
        {
            return await this.Synchronize<StarshipViewModel>(url: UrlStarship);
        }

    }
}