using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Institution).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Field).IsRequired().HasMaxLength(100);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate);

            builder.HasOne(e => e.Applicant)
                   .WithMany(a => a.Educations)
                   .HasForeignKey(e => e.ApplicantId);
        }
    }
}
