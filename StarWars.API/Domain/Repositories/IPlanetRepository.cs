using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;

namespace StarWars.API.Domain.Repositories
{
    public interface IPlanetRepository
    {
        IEnumerable<Planet> GetAll();
        Task<bool> Synchronize();

    }
}