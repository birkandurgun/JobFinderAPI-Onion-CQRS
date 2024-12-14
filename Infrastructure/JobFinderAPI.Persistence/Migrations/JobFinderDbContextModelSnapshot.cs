﻿// <auto-generated />
using System;
using JobFinderAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobFinderAPI.Persistence.Migrations
{
    [DbContext(typeof(JobFinderDbContext))]
    partial class JobFinderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicantSkill", b =>
                {
                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicantId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ApplicantSkills", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Common.User.SystemUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailVerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("CountryCode", "PhoneNumber")
                        .IsUnique();

                    b.ToTable("SystemUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Educations", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Experiences", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.JobApplication", b =>
                {
                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobPostingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicantId", "JobPostingId");

                    b.HasIndex("JobPostingId");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.JobPosting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sector")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkPreference")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("JobPostings", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId")
                        .IsUnique();

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("JobPostingSkill", b =>
                {
                    b.Property<Guid>("JobPostingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobPostingId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobPostingSkills", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("JobFinderAPI.Domain.Entities.Common.User.SystemUser");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Applicant", b =>
                {
                    b.HasBaseType("JobFinderAPI.Domain.Entities.Common.User.SystemUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Applicants", (string)null);
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Employer", b =>
                {
                    b.HasBaseType("JobFinderAPI.Domain.Entities.Common.User.SystemUser");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyName")
                        .IsUnique()
                        .HasFilter("[CompanyName] IS NOT NULL");

                    b.ToTable("Employers", (string)null);
                });

            modelBuilder.Entity("ApplicantSkill", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Applicant", "Applicant")
                        .WithMany("ApplicantSkills")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobFinderAPI.Domain.Entities.Skill", "Skill")
                        .WithMany("ApplicantSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Education", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Applicant", "Applicant")
                        .WithMany("Educations")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Experience", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Applicant", "Applicant")
                        .WithMany("Experiences")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.JobApplication", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Applicant", "Applicant")
                        .WithMany("JobApplications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobFinderAPI.Domain.Entities.JobPosting", "JobPosting")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("JobPosting");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.JobPosting", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Employer", "Employer")
                        .WithMany("JobPostings")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Location", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Employer", "Employer")
                        .WithOne("Location")
                        .HasForeignKey("JobFinderAPI.Domain.Entities.Location", "EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Resume", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Applicant", "Applicant")
                        .WithOne("Resume")
                        .HasForeignKey("JobFinderAPI.Domain.Entities.Resume", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("JobPostingSkill", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.JobPosting", "JobPosting")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobFinderAPI.Domain.Entities.Skill", "Skill")
                        .WithMany("JobPostingSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosting");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Admin", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Common.User.SystemUser", null)
                        .WithOne()
                        .HasForeignKey("JobFinderAPI.Domain.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Applicant", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Common.User.SystemUser", null)
                        .WithOne()
                        .HasForeignKey("JobFinderAPI.Domain.Entities.Applicant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Employer", b =>
                {
                    b.HasOne("JobFinderAPI.Domain.Entities.Common.User.SystemUser", null)
                        .WithOne()
                        .HasForeignKey("JobFinderAPI.Domain.Entities.Employer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.JobPosting", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("RequiredSkills");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Skill", b =>
                {
                    b.Navigation("ApplicantSkills");

                    b.Navigation("JobPostingSkills");
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Applicant", b =>
                {
                    b.Navigation("ApplicantSkills");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("JobApplications");

                    b.Navigation("Resume")
                        .IsRequired();
                });

            modelBuilder.Entity("JobFinderAPI.Domain.Entities.Employer", b =>
                {
                    b.Navigation("JobPostings");

                    b.Navigation("Location")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
