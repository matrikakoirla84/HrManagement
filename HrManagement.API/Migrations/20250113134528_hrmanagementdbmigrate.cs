using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class hrmanagementdbmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHubProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedTs = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInfo_Email",
                table: "CandidateInfo",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateInfo");
        }
    }
}
