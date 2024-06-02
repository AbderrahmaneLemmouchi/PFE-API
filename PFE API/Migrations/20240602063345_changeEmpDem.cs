using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_API.Migrations
{
    /// <inheritdoc />
    public partial class changeEmpDem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemuneree",
                table: "Demandes",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Demandes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LienVersJustification",
                table: "Demandes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Demandes");

            migrationBuilder.DropColumn(
                name: "LienVersJustification",
                table: "Demandes");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemuneree",
                table: "Demandes",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }
    }
}
