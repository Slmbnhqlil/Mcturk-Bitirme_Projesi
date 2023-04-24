namespace McTurk.Domain
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationNumber { get; set; } // Ruhsat No
        public DateTime RegistrationDate { get; set; } // Trafiğe çıkış tarihi
        public int AppointmentReportsId { get; set; }
        public int UsersId { get; set; }
    }
}