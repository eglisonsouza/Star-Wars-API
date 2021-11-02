using System.Collections.Generic;
using System.Linq;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Domain.Extensions
{
    public static class PlanetExtensions
    {
        public static List<Planet> ConvertToPlanet(this List<PlanetViewModel> planetViewModels)
        {
            return planetViewModels.Select(ConvertToPlanet).ToList();
        }
        
        private static Planet ConvertToPlanet(PlanetViewModel planetViewModel)
        {
            return new Planet()
            {
                Id = planetViewModel.GetId(),
                Name = planetViewModel.Name,
                Rotation = planetViewModel.Rotation.ToDouble(),
                Orbital = planetViewModel.Orbital.ToDouble(),
                Diameter = planetViewModel.Diameter.ToDouble(),
                Climate = planetViewModel.Climate,
                Population = planetViewModel.Population.ToLong()
            };
        }
    }
}