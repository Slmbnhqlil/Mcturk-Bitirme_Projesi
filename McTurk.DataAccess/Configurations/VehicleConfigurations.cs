using McTurk.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTurk.DataAccess.Configurations
{
    public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));
            builder.HasKey(x => x.Id);

            builder.Property(u => u.PlateNumber)
               .IsRequired()
               .HasColumnType("nvarchar(20)");

            builder.Property(u => u.RegistrationNumber)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            builder.Property(u => u.RegistrationDate)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            builder
                .HasOne(u => u.AppointmentReports)
                .WithMany()
                .HasForeignKey(builder => builder.AppointmentReportsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Users)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
