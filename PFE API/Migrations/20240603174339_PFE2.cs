using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class PFE2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                           name: "rattache",
                           table: "Equipes",
                           type: "integer",
                           nullable: false,
                           defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "rattache",
               table: "Equipes");
        }
    }
}
