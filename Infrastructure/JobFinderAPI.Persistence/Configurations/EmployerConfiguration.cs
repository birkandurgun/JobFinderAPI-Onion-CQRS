using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employers");

            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(200);
            
            builder.HasIndex(e => e.CompanyName).IsUnique();

            builder.HasOne(e => e.Location)
                   .WithOne(l => l.Employer)
                   .HasForeignKey<Location>(l => l.EmployerId);

            builder.HasMany(e => e.JobPostings)
                   .WithOne(j => j.Employer)
                   .HasForeignKey(j => j.EmployerId); 
        }
    }
}
