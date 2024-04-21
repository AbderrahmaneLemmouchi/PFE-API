using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class addEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    NSS = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Prenom2 = table.Column<string>(type: "text", nullable: false),
                    NomArabe = table.Column<string>(type: "text", nullable: false),
                    PrenomArabe = table.Column<string>(type: "text", nullable: false),
                    Prenom2Arabe = table.Column<string>(type: "text", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NomJeuneFille = table.Column<string>(type: "text", nullable: false),
                    LieuNaissance = table.Column<string>(type: "text", nullable: false),
                    PaysNaissance = table.Column<string>(type: "text", nullable: false),
                    WilayaNaissance = table.Column<string>(type: "text", nullable: false),
                    CommuneNaissance = table.Column<string>(type: "text", nullable: false),
                    Sexe = table.Column<string>(type: "text", nullable: false),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    SituationFamiliale = table.Column<string>(type: "text", nullable: false),
                    Nationalites = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: false),
                    Reliquat = table.Column<int>(type: "integer", nullable: false),
                    IsResponsable = table.Column<bool>(type: "boolean", nullable: false),
                    IDEquipe = table.Column<int>(type: "integer", nullable: false),
                    IDResponsable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Matricule);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
