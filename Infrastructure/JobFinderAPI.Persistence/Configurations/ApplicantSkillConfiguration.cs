using JobFinderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Infrastructure.Data.Configurations
{
    public class ApplicantSkillConfiguration : IEntityTypeConfiguration<ApplicantSkill>
    {
        public void Configure(EntityTypeBuilder<ApplicantSkill> builder)
        {
            builder.ToTable("ApplicantSkills");

            builder.HasKey(aps => new { aps.ApplicantId, aps.SkillId });

            builder.HasOne(aps => aps.Applicant)
                   .WithMany(a => a.ApplicantSkills)
                   .HasForeignKey(aps => aps.ApplicantId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(aps => aps.Skill)
                   .WithMany(s => s.ApplicantSkills)
                   .HasForeignKey(aps => aps.SkillId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
