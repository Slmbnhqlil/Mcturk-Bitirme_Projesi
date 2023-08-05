namespace McTurk.Domain
{
    public class AppointmentReport
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int VehicleTypeId { get; set; }
        public int StationId { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }

        public IEnumerable<VehicleType> VehicleType { get; set; }
        public IEnumerable<Station> Stations { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}