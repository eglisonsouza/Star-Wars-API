using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace StarWars.API.Domain.ViewModels
{
    public class PlanetViewModel
    {
        [JsonPropertyName("url")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("rotation_period")]
        public string Rotation { get; set; }
        
        [JsonPropertyName("orbital_period")]
        public string Orbital { get; set; }
        
        [JsonPropertyName("diameter")]
        public string Diameter { get; set; }
        
        [JsonPropertyName("climate")]
        public string Climate { get; set; }
        
        [JsonPropertyName("population")]
        public string Population { get; set; }

        public int GetId()
        {
            return Convert.ToInt32(Id.Split("/").Where(id => !String.IsNullOrEmpty(id)).LastOrDefault());
        }

    }
}