using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_lerz09_contatti_CF.Migrations
{
    /// <inheritdoc />
    public partial class CambioNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contattos",
                table: "Contattos");

            migrationBuilder.RenameTable(
                name: "Contattos",
                newName: "Contatti");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatti",
                table: "Contatti",
                column: "ContattoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatti",
                table: "Contatti");

            migrationBuilder.RenameTable(
                name: "Contatti",
                newName: "Contattos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contattos",
                table: "Contattos",
                column: "ContattoID");
        }
    }
}
