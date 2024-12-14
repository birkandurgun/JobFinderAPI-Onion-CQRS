using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinderAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnJobPosting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sector",
                table: "JobPostings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkPreference",
                table: "JobPostings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "WorkPreference",
                table: "JobPostings");
        }
    }
}
