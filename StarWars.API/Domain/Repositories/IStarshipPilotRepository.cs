using System.Collections.Generic;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Domain.Repositories
{
    public interface IStarshipPilotRepository
    {
        void AssociateShipPilot(List<PilotViewModel> pilotsViewModel);
    }
}