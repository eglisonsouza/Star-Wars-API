using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace StarWars.API.Domain.ViewModels
{
    public class StarshipViewModel
    {
        [JsonPropertyName("url")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("passengers")]
        public string Passenger { get; set; }
        [JsonPropertyName("cargo_capacity")]
        public string Charge { get; set; }
        [JsonPropertyName("MGLT")]
        public string Class { get; set; }
        
        public int GetId()
        {
            return Convert.ToInt32(Id.Split("/").Where(id => !String.IsNullOrEmpty(id)).LastOrDefault());
        }
    }
}