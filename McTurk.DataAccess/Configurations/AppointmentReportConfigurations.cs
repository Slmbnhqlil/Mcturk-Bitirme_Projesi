using McTurk.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTurk.DataAccess.Configurations
{
    public class AppointmentReportConfigurations : IEntityTypeConfiguration<AppointmentReport>
    {
        public void Configure(EntityTypeBuilder<AppointmentReport> builder)
        {
            builder.ToTable(nameof(AppointmentReport));
            builder.HasKey(a => a.Id);

            builder.Property(b => b.TransactionDate)
                .IsRequired()
                .HasColumnType("datetime2(0)");

            builder
                .HasOne(b => b.VehicleType)
                .WithMany()
                .HasForeignKey(builder => builder.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(b => b.Users)
                .WithMany()
                .HasForeignKey(builder => builder.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(b => b.Stations)
                .WithMany()
                .HasForeignKey(builder => builder.StationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
