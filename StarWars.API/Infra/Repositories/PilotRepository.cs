using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Extensions;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class PilotRepository : BaseRepository, IPilotRepository
    {
        private readonly IPilotSynchronize _pilotSynchronize;
        private readonly IStarshipPilotRepository _starshipPilotRepository;

        private const string ScriptInsert =
            @"INSERT INTO Pilots (Id, Name, BirthYear, IdPlanet) VALUES (@Id, @Name, @BirthYear, @IdPlanet)";

        public PilotRepository(GenericDA genericDa, IPilotSynchronize pilotSynchronize,
            IStarshipPilotRepository starshipPilotRepository) : base(genericDa)
        {
            _pilotSynchronize = pilotSynchronize;
            _starshipPilotRepository = starshipPilotRepository;
        }

        public async Task<bool> Synchronize()
        {
            List<PilotViewModel> pilotsViewModel = (await _pilotSynchronize.Synchronize());

            await GenericDa.Insert(
                objects: pilotsViewModel.ConvertToPilot(),
                sql: ScriptInsert);

            _starshipPilotRepository.AssociateShipPilot(pilotsViewModel);

            return true;
        }
    }
}