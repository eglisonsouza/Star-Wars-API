using System.Collections.Generic;

namespace StarWars.API.Domain.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public Planet Planet { get; set; }
        public List<Starship> Starships { get; set; }
    }
}