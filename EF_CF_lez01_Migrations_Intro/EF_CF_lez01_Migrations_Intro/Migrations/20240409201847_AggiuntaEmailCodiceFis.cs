using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CF_lez01_Migrations_Intro.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaEmailCodiceFis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodiceFiscale",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CodiceFiscale",
                table: "Contacts",
                column: "CodiceFiscale",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_CodiceFiscale",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CodiceFiscale",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");
        }
    }
}
