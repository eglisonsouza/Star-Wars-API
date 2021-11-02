using System;
using System.Collections.Generic;
using System.Linq;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Shared.Utils
{
    public static class StarshipPilotUtils
    {
        public static List<Object> ConvertToPilotStarship(this List<PilotViewModel> pilotsViewModel)
        {
            return pilotsViewModel.SelectMany(ConvertToPilotStarship).ToList();
        }
        
        private static IEnumerable<Object> ConvertToPilotStarship(PilotViewModel pilotViewModel)
        {
            return pilotViewModel.GetIdStarships().Select(idStarship => new {IdPilot = pilotViewModel.GetId(), IdStarship = idStarship});
        }
    }
}