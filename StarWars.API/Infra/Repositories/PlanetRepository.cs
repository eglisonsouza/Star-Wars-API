using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Infra.DataAccess;
using System;
using System.Linq;
using StarWars.API.Domain.Extensions;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Infra.Repositories
{
    public class PlanetRepository : BaseRepository, IPlanetRepository
    {
        private readonly IPlanetSynchronize _planetSynchronize;

        public PlanetRepository(GenericDA genericDa, IPlanetSynchronize planetSynchronize) : base(genericDa)
        {
            _planetSynchronize = planetSynchronize;
        }

        public IEnumerable<Planet> GetAll()
        {
            return this.GenericDa.Get<Planet>();
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                await GenericDa.Insert<Planet>(objects: (await _planetSynchronize.Synchronize()).ConvertToPlanet());
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

       
    }
}