using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Infra.DataAccess;
using StarWars.API.Infra.Services;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Infra.Repositories
{
    public class StarshipRepository : BaseRepository, IStarshipRepository
    {
        private readonly IStarshipSynchronize _starshipSynchronize;

        public StarshipRepository(GenericDA genericDa, IStarshipSynchronize starshipSynchronize) : base(genericDa)
        {
            _starshipSynchronize = starshipSynchronize;
        }

        public IEnumerable<Starship> GetAll()
        {
            return GenericDa.Get<Starship>();
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                await GenericDa.Insert<Starship>(objects: (await _starshipSynchronize.Synchronize()).ConvertToPlanet());

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}