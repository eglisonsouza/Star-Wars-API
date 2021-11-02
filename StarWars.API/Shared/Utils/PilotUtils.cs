using System;
using System.Collections.Generic;
using System.Linq;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Shared.Utils
{
    public static class PilotUtils
    {
        public static List<Object> ConvertToPilot(this List<PilotViewModel> pilotsViewModel)
        {
            return pilotsViewModel.Select(ConvertToPilot).ToList();
        }

        private static Object ConvertToPilot(PilotViewModel pilotViewModel)
        {
            return new
            {
                Id = pilotViewModel.GetId(),
                Name = pilotViewModel.Name,
                BirthYear = pilotViewModel.BirthYear,
                IdPlanet = pilotViewModel.GetIdPlanet(),
                IdsStarship = pilotViewModel.GetIdStarships()
            };
        }
    }
}