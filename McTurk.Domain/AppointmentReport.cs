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

        public ICollection<VehicleType> VehicleType { get; set; }
        public ICollection<Station> Stations { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}