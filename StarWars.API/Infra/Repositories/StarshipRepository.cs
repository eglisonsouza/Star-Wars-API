using System.Collections.Generic;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class StarshipRepository : BaseRepository, IStarshipRepository
    {
        public StarshipRepository(ContextDb contextDb) : base(contextDb)
        {
        }

        public IEnumerable<Starship> GetAll()
        {
            return this.ContextDb.Get<Starship>();
        }
    }
}