using System;
using System.Linq;
using System.Threading.Tasks;
using StarWars.API.Domain.Arguments.HistoryTrips;
using StarWars.API.Domain.Repositories;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class HistoryTripsRepository : BaseRepository, IHistoryTripsRepository
    {
        private const string ScriptInsertRegisterExit =
            "INSERT INTO HistoryTrips (IdPilot, IdStarShip, DateExit) VALUES (@IdPilot, @IdStarShip, @DateExit)";

        private const string ScriptInsertRegisterArrival =
            "UPDATE HistoryTrips SET DateArrival = @DateArrival WHERE IdPilot = @IdPilot AND IdStarShip = @IdStarShip AND DateArrival IS NULL";

        private const string ScriptSelectStarshipPilot =
            "SELECT * FROM StarshipsPilots WHERE IdPilot = @IdPilot AND IdStarship = @IdStarship AND FlagAuthorized = @FlagAuthorized";

        private const string ScriptSelectStarshipPilotInTransit =
            "SELECT * FROM HistoryTrips WHERE IdPilot = @IdPilot AND IdStarship = @IdStarship AND DateArrival IS NULL";

        public HistoryTripsRepository(GenericDA genericDa) : base(genericDa)
        {
        }

        public async Task<int> RegisterExit(RegisterRequest registerRequest)
        {
            ValidateRegisterExit(registerRequest);

            return await GenericDa.Insert(
                sql: ScriptInsertRegisterExit,
                param: new
                {
                    IdPilot = registerRequest.IdPilot,
                    IdStarShip = registerRequest.IdStarship,
                    DateExit = DateTime.Now
                });
        }

        private void ValidateRegisterExit(RegisterRequest registerRequest)
        {
            if (!IsAutorized(registerRequest)) throw new Exception("Starship not is autorized");
            
            if (InTransit(registerRequest)) throw new Exception("Starship is in transit");
        }

        private bool IsAutorized(RegisterRequest registerRequest)
        {
            return GenericDa.Get<object>(
                sql: ScriptSelectStarshipPilot
                ,
                param: new
                {
                    IdPilot = registerRequest.IdPilot,
                    IdStarship = registerRequest.IdStarship,
                    FlagAuthorized = 1
                }).Any();
        }

        private bool InTransit(RegisterRequest registerRequest)
        {
            return GenericDa.Get<object>(
                sql: ScriptSelectStarshipPilotInTransit
                ,
                param: new
                {
                    IdPilot = registerRequest.IdPilot,
                    IdStarship = registerRequest.IdStarship
                }).Any();
        }

        public async Task<int> RegisterArrival(RegisterRequest registerRequest)
        {
            
            return await GenericDa.Insert(
                sql: ScriptInsertRegisterArrival,
                param: new
                {
                    IdPilot = registerRequest.IdPilot,
                    IdStarShip = registerRequest.IdStarship,
                    DateArrival = DateTime.Now
                });
        }
    }
}