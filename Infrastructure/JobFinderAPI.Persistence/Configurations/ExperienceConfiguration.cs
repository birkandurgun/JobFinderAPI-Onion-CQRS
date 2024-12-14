using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Company).IsRequired().HasMaxLength(200);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate);
            builder.Property(e => e.Description).HasMaxLength(400);

            builder.HasOne(e => e.Applicant)
                   .WithMany(a => a.Experiences)
                   .HasForeignKey(e => e.ApplicantId); 
        }
    }
}
