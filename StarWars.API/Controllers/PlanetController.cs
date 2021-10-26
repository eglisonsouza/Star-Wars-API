using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Domain.Repositories;

namespace StarWars.API.Controllers
{
    [Route("api/v1/planet")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetController(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        //[SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um curso")]
        //[SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_planetRepository.GetAll());
        }

    }
}