using System.Collections.Generic;

namespace StarWars.API.Domain.ViewModels
{
    public class StarshipPilotViewModel
    {
        public int IdPilot { get; set; }
        public List<int> IdsStarship { get; set; }
    }
}