using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;

namespace StarWars.API.Infra.Services.Synchronize
{
    public class PlanetSynchronize : SynchronizeBase, IPlanetSynchronize
    {
        private const string UrlPlanet = "https://swapi.dev/api/planets";


        public PlanetSynchronize(IHttpRequest httpRequest) : base(httpRequest)
        {
        }
        
        public async Task<List<PlanetViewModel>> Synchronize()
        {
            return await this.Synchronize<PlanetViewModel>(url: UrlPlanet);
        }
    }
}