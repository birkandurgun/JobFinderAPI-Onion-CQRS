using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.ToTable("JobPostings");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title).IsRequired().HasMaxLength(200);
            builder.Property(j => j.Description).IsRequired();
            builder.Property(j => j.WorkPreference).IsRequired();
            builder.Property(j => j.Sector).IsRequired();

            builder.HasOne(j => j.Employer)
                   .WithMany(e => e.JobPostings)
                   .HasForeignKey(j => j.EmployerId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
