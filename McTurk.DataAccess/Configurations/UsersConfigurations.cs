using McTurk.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTurk.DataAccess.Configurations
{
    public class UsersConfigurations : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable(nameof(Users));
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            
            builder.Property(b => b.Email)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(b => b.IdentityNumber)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.HasOne(_ => _.Vehicle)
                .WithOne(_ => _.Users)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
