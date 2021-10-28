using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Infra.Services.Synchronize
{
    public class StarshipSynchronize: SynchronizeBase, IStarshipSynchronize
    {
        private const string UrlStarship = "https://swapi.dev/api/starships";

        public StarshipSynchronize(IHttpRequest httpRequest) : base(httpRequest)
        {
        }
        public async Task<List<StarshipViewModel>> Synchronize()
        {
            return await this.Synchronize<StarshipViewModel>(url: UrlStarship);
        }

    }
}