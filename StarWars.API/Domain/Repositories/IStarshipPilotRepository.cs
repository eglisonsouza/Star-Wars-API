using System.Collections.Generic;

namespace StarWars.API.Domain.Repositories
{
    public interface IStarshipPilotRepository
    {
        void AssociateShipPilot(int idPilot, List<int> idStarships);
    }
}