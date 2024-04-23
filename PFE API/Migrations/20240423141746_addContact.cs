using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class addContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEntre",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSortie",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NbAnneeExperienceExterne",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbAnneeExperienceInterne",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbEnfant",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    MatriculeEmp = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Valeur = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => new { x.MatriculeEmp, x.Type, x.Valeur });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateEntre",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateSortie",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NbAnneeExperienceExterne",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NbAnneeExperienceInterne",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NbEnfant",
                table: "Employees");
        }
    }
}
