using JobFinderAPI.Domain.Entities.Common.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinderAPI.Persistence.Configurations
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUsers");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.CountryCode).HasMaxLength(3).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(12).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => new { u.CountryCode, u.PhoneNumber }).IsUnique();
        }
    }
}
