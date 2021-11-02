using System.Collections.Generic;
using System.Linq;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Domain.Extensions
{
    public static class StarshipExtensions
    {
        public static List<Starship> ConvertToPlanet(this List<StarshipViewModel> planetViewModels)
        {
            return planetViewModels.Select(ConvertToStarship).ToList();
        }

        private static Starship ConvertToStarship(StarshipViewModel starshipViewModel)
        {
            return new Starship()
            {
                Id = starshipViewModel.GetId(),
                Name = starshipViewModel.Name,
                Model = starshipViewModel.Model,
                Passenger = starshipViewModel.Passenger.ToInt(),
                Charge = starshipViewModel.Charge.ToDouble(),
                Class = starshipViewModel.Class
            };
        }
    }
}