using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Shared.Domain.Services;

namespace StarWars.API.Infra.Services.Synchronize
{
    public class PilotSynchronize : SynchronizeBase, IPilotSynchronize
    {
        private const string UrlPilot = "https://swapi.dev/api/people";
        
        public PilotSynchronize(IHttpRequest httpRequest) : base(httpRequest)
        {
        }

        public async Task<List<PilotViewModel>> Synchronize()
        {
            return await this.Synchronize<PilotViewModel>(url: UrlPilot);
        }
    }
}