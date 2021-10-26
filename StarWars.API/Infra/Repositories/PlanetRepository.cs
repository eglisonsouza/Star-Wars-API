using System.Collections.Generic;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class PlanetRepository : BaseRepository, IPlanetRepository
    {
        public PlanetRepository(ContextDb contextDb) : base(contextDb)
        {
        }
        public IEnumerable<Planet> GetAll()
        {
            return this.ContextDb.Get<Planet>();
        }

    }
}