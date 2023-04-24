using McTurk.DataAccess.Configurations;
using McTurk.Domain;
using Microsoft.EntityFrameworkCore;

namespace McTurk.DataAccess
{
    public class McTurkContext : DbContext
    {
        private const string ConnectionString =
            "Server=.;Database=McTurk;Integrated Security=true";

        public DbSet<Users> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<AppointmentReport> AppointmentReports { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfigurations());
            modelBuilder.ApplyConfiguration(new VehicleConfigurations());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfigurations());
            modelBuilder.ApplyConfiguration(new StationConfigurations());
            modelBuilder.ApplyConfiguration(new AppointmentReportConfigurations());
        }

    }
}