namespace McTurk.Domain
{
    public class AppointmentReportDto
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StationId { get; set; }
        public int UserId { get; set; }

    }
}