using System.Collections.Generic;
using StarWars.API.Domain.Entities;

namespace StarWars.API.Domain.Repositories
{
    public interface IPlanetRepository
    {
        IEnumerable<Planet> GetAll();

    }
}