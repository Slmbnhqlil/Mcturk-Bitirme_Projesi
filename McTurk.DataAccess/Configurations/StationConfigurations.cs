using McTurk.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTurk.DataAccess.Configurations
{
    public class StationConfigurations : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable(nameof(Station));
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            builder.HasOne(_ => _.Vehicle)
                .WithMany()
                .HasForeignKey(s => s.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Station() { Id = 1, Name = "Haraççı" },
                new Station() { Id = 1, Name = "Mimar Sinan" },
                new Station() { Id = 1, Name = "Çatalca" }
                );
        }
    }
}
