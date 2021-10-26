using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Domain.Repositories;

namespace StarWars.API.Controllers
{
    [Route("api/v1/starschip")]
    [ApiController]
    public class StarshipController : ControllerBase
    {

        private readonly IStarshipRepository _starshipRepository;

        public StarshipController(IStarshipRepository starshipRepository)
        {
            _starshipRepository = starshipRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_starshipRepository.GetAll());
        }
    }
}