using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Infra.DataAccess;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Infra.Repositories
{
    public class StarshipPilotRepository : BaseRepository, IStarshipPilotRepository
    {
        private const string ScriptInsert =
            "INSERT INTO StarshipsPilots (IdPilot, IdStarship) VALUES (@IdPilot, @IdStarship);";

        public StarshipPilotRepository(GenericDA genericDa) : base(genericDa)
        {
        }
        
        public async void AssociateShipPilot(List<PilotViewModel> pilotsViewModel)
        {
            await GenericDa.Insert(
                objects: pilotsViewModel.ConvertToPilotStarship(),
                sql: ScriptInsert);
        }
        
    }
}