namespace McTurk.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationNumber { get; set; } // Ruhsat No
        public DateTime RegistrationDate { get; set; } // Trafiğe çıkış yılı
        public int AppointmentReportsId { get; set; }
        public int UsersId { get; set; }
        public IEnumerable<AppointmentReport> AppointmentReports { get; set; }
        public Users Users { get; set; }
    }
}