﻿namespace McTurk.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
