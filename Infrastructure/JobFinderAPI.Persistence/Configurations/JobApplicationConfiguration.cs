using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("Applications");

            builder.HasKey(ja => new { ja.ApplicantId, ja.JobPostingId });

            builder.HasOne(a => a.Applicant)
                   .WithMany(applicant => applicant.JobApplications)
                   .HasForeignKey(a => a.ApplicantId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(a => a.JobPosting)
                   .WithMany(jp => jp.JobApplications)
                   .HasForeignKey(a => a.JobPostingId)
                   .OnDelete(DeleteBehavior.NoAction);  
        }
    }
}
