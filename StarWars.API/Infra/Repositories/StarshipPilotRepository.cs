using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Repositories;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class StarshipPilotRepository : BaseRepository, IStarshipPilotRepository
    {
        private const string ScriptInsert =
            "INSERT INTO StarshipsPilots (IdPilot, IdStarship) VALUES (@IdPilot, @IdStarship);";

        public StarshipPilotRepository(GenericDA genericDa) : base(genericDa)
        {
        }

        public void AssociateShipPilot(int idPilot, List<int> idStarships)
        {
            //async void InsertIds(int id) => await GenericDa.Insert<Object>(sql: ScriptInsert, param: new {IdPilot = idPilot, IdStarship = id});

            //idStarships.ForEach(InsertIds);

        }
    }
}