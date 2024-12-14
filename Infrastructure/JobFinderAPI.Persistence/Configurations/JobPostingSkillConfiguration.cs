using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class JobPostingSkillConfiguration : IEntityTypeConfiguration<JobPostingSkill>
    {
        public void Configure(EntityTypeBuilder<JobPostingSkill> builder)
        {
            builder.ToTable("JobPostingSkills");

            builder.HasKey(js => new { js.JobPostingId, js.SkillId });

            builder.HasOne(js => js.JobPosting)
                   .WithMany(j => j.RequiredSkills)
                   .HasForeignKey(js => js.JobPostingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(js => js.Skill)
                   .WithMany(s => s.JobPostingSkills)
                   .HasForeignKey(js => js.SkillId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
