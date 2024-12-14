using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinderAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ResetPasswordChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "SystemUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpiration",
                table: "SystemUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpiration",
                table: "SystemUsers");
        }
    }
}
