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
        private readonly IPlanetService _planetService;

        public PlanetRepository(ContextDb contextDb, IPlanetService planetService) : base(contextDb)
        {
            _planetService = planetService;
        }

        public IEnumerable<Planet> GetAll()
        {
            return this.ContextDb.Get<Planet>();
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                (await _planetService.Synchronize()).ForEach(planet =>
                {
                    this.Insert(new Planet()
                    {
                        Id = planet.GetId(),
                        Name = planet.Name,
                        Rotation = Convert.ToDouble(planet.Rotation.ToDouble()),
                        Orbital = Convert.ToDouble(planet.Orbital.ToDouble()),
                        Diameter = Convert.ToDouble(planet.Diameter.ToDouble()),
                        Climate = planet.Climate,
                        Population = Convert.ToInt64(planet.Population.ToLong())
                    });
                });

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> Insert(Planet planet)
        {
            return this.ContextDb.Insert<Planet>(planet);
        }
    }
}