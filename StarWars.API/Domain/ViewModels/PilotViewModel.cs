using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using StarWars.API.Shared.Utils;

namespace StarWars.API.Domain.ViewModels
{
    public class PilotViewModel
    {
        [JsonPropertyName("url")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }
        
        [JsonPropertyName("homeworld")]
        public string IdPlanet { get; set; }
        
        
        [JsonPropertyName("starships")]
        public List<string> IdStarships { get; set; }

        public List<int> GetIdStarships()
        {
            return IdStarships
                .Select(value => Convert.ToInt32(value.Split("/").LastOrDefault(id => !string.IsNullOrEmpty(id)))).ToList();
        }

        public int GetId()
        {
            return Convert.ToInt32(Id.Split("/").LastOrDefault(id => !string.IsNullOrEmpty(id)));
        }
        
        public int GetIdPlanet()
        {
            return Convert.ToInt32(IdPlanet.Split("/").LastOrDefault(id => !string.IsNullOrEmpty(id)));
        }
        
        public List<long> GetIdsStarshipt()
        {
            return IdStarships.Select(id => id.Split("/").LastOrDefault(value => !string.IsNullOrEmpty(value)).ToLong()).ToList();
        }
    }
}