using System;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class PilotRepository : BaseRepository, IPilotRepository
    {
        private readonly IPilotSynchronize _pilotSynchronize;
        private readonly IStarshipPilotRepository _starshipPilotRepository;

        private const string ScriptInsert =
            @"INSERT INTO Pilots (Id, Name, BirthYear, IdPlanet) VALUES (@Id, @Name, @BirthYear, @IdPlanet)";

        public PilotRepository(ContextDb contextDb, IPilotSynchronize pilotSynchronize,
            IStarshipPilotRepository starshipPilotRepository) : base(contextDb)
        {
            _pilotSynchronize = pilotSynchronize;
            _starshipPilotRepository = starshipPilotRepository;
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                (await _pilotSynchronize.Synchronize()).ForEach(pilot =>
                {
                    ContextDb?.Insert(
                        ScriptInsert,
                        new
                        {
                            Id = pilot.GetId(),
                            Name = pilot.Name,
                            BirthYear = pilot.BirthYear,
                            IdPlanet = pilot.GetIdPlanet()
                        });
                    _starshipPilotRepository.AssociateShipPilot(idPilot: pilot.GetId(),
                        idStarships: pilot.GetIdStarships());
                });

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}