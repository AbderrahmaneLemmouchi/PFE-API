using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratsRT",
                columns: table => new
                {
                    CodeContrat = table.Column<string>(type: "text", nullable: false),
                    MatriculeEmp = table.Column<string>(type: "text", nullable: false),
                    CategorieContrat = table.Column<string>(type: "text", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateFinPeriodeEssai = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegimeTravail = table.Column<string>(type: "text", nullable: false),
                    Poste = table.Column<string>(type: "text", nullable: false),
                    Actif = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratsRT", x => x.CodeContrat);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratsRT");
        }
    }
}
