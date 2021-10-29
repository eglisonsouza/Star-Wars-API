using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Infra.DataAccess;
using System;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Infra.Repositories
{
    public class PlanetRepository : BaseRepository, IPlanetRepository
    {
        private readonly IPlanetSynchronize _planetSynchronize;

        public PlanetRepository(ContextDb contextDb, IPlanetSynchronize planetSynchronize) : base(contextDb)
        {
            _planetSynchronize = planetSynchronize;
        }

        public IEnumerable<Planet> GetAll()
        {
            return this.ContextDb.Get<Planet>();
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                (await _planetSynchronize.Synchronize()).ForEach(planet =>
                {
                    this.Insert(new Planet()
                    {
                        Id = planet.GetId(),
                        Name = planet.Name,
                        Rotation = planet.Rotation.ToDouble(),
                        Orbital = planet.Orbital.ToDouble(),
                        Diameter = planet.Diameter.ToDouble(),
                        Climate = planet.Climate,
                        Population = planet.Population.ToLong()
                    });
                });

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<int> Insert(Planet planet)
        {
            return this.ContextDb.Insert<Planet>(planet);
        }
    }
}