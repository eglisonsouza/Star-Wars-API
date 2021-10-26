namespace StarWars.API.Domain.Entities
{
    public class Starship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int  Passenger { get; set; }
        public double Charge { get; set; }
        public string Class { get; set; }
    }
}