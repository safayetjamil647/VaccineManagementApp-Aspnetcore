using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicaTeams.Data.Migrations
{
    public partial class Applyonlinedatanew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyOnlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PreferedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    Abnormalities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyOnlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyOnlines_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyOnlines_VenueId",
                table: "ApplyOnlines",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyOnlines");
        }
    }
}
