using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicants");

            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();

            builder.HasOne(a => a.Resume)
                   .WithOne(r => r.Applicant)
                   .HasForeignKey<Resume>(r => r.ApplicantId);

            builder.HasMany(a => a.Educations)
                   .WithOne(e => e.Applicant)
                   .HasForeignKey(e => e.ApplicantId);  

            builder.HasMany(a => a.Experiences)
                   .WithOne(e => e.Applicant)
                   .HasForeignKey(e => e.ApplicantId);  

        }
    }
}
