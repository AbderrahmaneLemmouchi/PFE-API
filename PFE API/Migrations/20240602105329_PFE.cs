using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class PFE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatriculeEmp = table.Column<string>(type: "text", nullable: false),
                    IDExercice = table.Column<int>(type: "integer", nullable: false),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatriculeEmp = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Valeur = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    NSS = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Prenom2 = table.Column<string>(type: "text", nullable: true),
                    NomArabe = table.Column<string>(type: "text", nullable: false),
                    PrenomArabe = table.Column<string>(type: "text", nullable: false),
                    Prenom2Arabe = table.Column<string>(type: "text", nullable: true),
                    DateNaissance = table.Column<DateOnly>(type: "date", nullable: false),
                    NomJeuneFille = table.Column<string>(type: "text", nullable: true),
                    NomJeuneFilleArabe = table.Column<string>(type: "text", nullable: true),
                    LieuNaissance = table.Column<string>(type: "text", nullable: false),
                    PaysNaissance = table.Column<string>(type: "text", nullable: false),
                    WilayaNaissance = table.Column<string>(type: "text", nullable: false),
                    CommuneNaissance = table.Column<string>(type: "text", nullable: false),
                    Sexe = table.Column<int>(type: "integer", nullable: false),
                    Titre = table.Column<int>(type: "integer", nullable: false),
                    SituationFamiliale = table.Column<int>(type: "integer", nullable: false),
                    Nationalites = table.Column<string>(type: "text", nullable: false),
                    LinkToPhoto = table.Column<string>(type: "text", nullable: false),
                    Reliquat = table.Column<int>(type: "integer", nullable: false),
                    IsResponsable = table.Column<bool>(type: "boolean", nullable: false),
                    IDEquipe = table.Column<int>(type: "integer", nullable: false),
                    IDResponsable = table.Column<string>(type: "text", nullable: true),
                    DateEntre = table.Column<DateOnly>(type: "date", nullable: false),
                    DateSortie = table.Column<DateOnly>(type: "date", nullable: true),
                    NbAnneeExperienceInterne = table.Column<int>(type: "integer", nullable: false),
                    NbAnneeExperienceExterne = table.Column<int>(type: "integer", nullable: false),
                    NbEnfant = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    IDEquipe = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEquipe = table.Column<string>(type: "text", nullable: false),
                    Responsable = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.IDEquipe);
                });

            migrationBuilder.CreateTable(
                name: "Exercices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Annee = table.Column<int>(type: "integer", nullable: false),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDDemande = table.Column<int>(type: "integer", nullable: false),
                    FromEtat = table.Column<int>(type: "integer", nullable: false),
                    ToEtat = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Par = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Matricule = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatriculeEmp = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EtatActuel = table.Column<int>(type: "integer", nullable: false),
                    TypeDoc = table.Column<int>(type: "integer", nullable: true),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: true),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: true),
                    TypeConge = table.Column<int>(type: "integer", nullable: true),
                    JourRecup = table.Column<DateOnly>(type: "date", nullable: true),
                    IsRemuneree = table.Column<bool>(type: "boolean", nullable: true),
                    Commentaire = table.Column<string>(type: "text", nullable: true),
                    NouvelleInformationMatricule = table.Column<string>(type: "text", nullable: true),
                    LienVersJustification = table.Column<string>(type: "text", nullable: true),
                    Importance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Demandes_Employees_NouvelleInformationMatricule",
                        column: x => x.NouvelleInformationMatricule,
                        principalTable: "Employees",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_NouvelleInformationMatricule",
                table: "Demandes",
                column: "NouvelleInformationMatricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContratsRT");

            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Exercices");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
