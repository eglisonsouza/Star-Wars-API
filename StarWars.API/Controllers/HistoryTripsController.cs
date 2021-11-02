using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Domain.Arguments.HistoryTrips;
using StarWars.API.Domain.Repositories;

namespace StarWars.API.Controllers
{
    [Route("api/v1/history-trips")]
    [ApiController]
    public class HistoryTripsController : ControllerBase
    {

        private readonly IHistoryTripsRepository _historyTripsRepository;

        public HistoryTripsController(IHistoryTripsRepository historyTripsRepository)
        {
            _historyTripsRepository = historyTripsRepository;
        }

        [HttpPost]
        [Route("exit")]
        public async Task<IActionResult> RegisterExit([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                return Ok(await _historyTripsRepository.RegisterExit(registerRequest));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        [Route("arrival")]
        public async Task<IActionResult> RegisterArrival([FromBody] RegisterRequest registerRequest)
        {
            return Ok(await _historyTripsRepository.RegisterArrival(registerRequest));
        }
    }
}