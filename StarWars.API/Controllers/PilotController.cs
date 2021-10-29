using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Domain.Repositories;

namespace StarWars.API.Controllers
{
    [Route("api/v1/pilot")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotController(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        [HttpGet]
        [Route("synchronize")]
        public async Task<IActionResult> Synchronize()
        {
            await _pilotRepository.Synchronize();
            return NoContent();
        }
    }
}