using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicaTeams.Data.Migrations
{
    public partial class IntialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineAmount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolunteerGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfVolunteer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCandidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Abnormalities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCandidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccineCandidate_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCandidate_VenueId",
                table: "VaccineCandidate",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccineCandidate");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
