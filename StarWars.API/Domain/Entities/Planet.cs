using Dapper.Contrib.Extensions;

namespace StarWars.API.Domain.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rotation { get; set; }
        public double Orbital { get; set; }
        public double Diameter { get; set; }
        public string Climate { get; set; }
        public long Population { get; set; }
    }
}