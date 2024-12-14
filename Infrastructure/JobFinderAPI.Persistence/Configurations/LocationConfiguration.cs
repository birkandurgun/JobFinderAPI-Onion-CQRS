using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.District).HasMaxLength(100);
            builder.Property(l => l.City).HasMaxLength(100);
            builder.Property(l => l.Country).HasMaxLength(100);
            builder.Property(l => l.AddressLine).HasMaxLength(250);

            builder.HasOne(l => l.Employer)
                   .WithOne(e => e.Location)
                   .HasForeignKey<Location>(l => l.EmployerId);
        }
    }
}
