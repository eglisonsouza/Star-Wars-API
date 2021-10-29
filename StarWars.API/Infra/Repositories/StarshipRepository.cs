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

        public StarshipRepository(ContextDb contextDb, IStarshipSynchronize starshipSynchronize) : base(contextDb)
        {
            _starshipSynchronize = starshipSynchronize;
        }

        public IEnumerable<Starship> GetAll()
        {
            return this.ContextDb.Get<Starship>();
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                (await _starshipSynchronize.Synchronize()).ForEach(starship =>
                {
                    this.Insert(new Starship()
                    {
                        Id = starship.GetId(),
                        Name = starship.Name,
                        Model = starship.Model,
                        Passenger = starship.Passenger.ToInt(),
                        Charge = starship.Charge.ToDouble(),
                        Class = starship.Class
                    });
                });

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<int> Insert(Starship starship)
        {
            return this.ContextDb.Insert<Starship>(starship);
        }
    }
}