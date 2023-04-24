namespace McTurk.Domain
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleId { get; set; }

        public IEnumerable<Vehicle> Vehicle { get; set;}
    }
}