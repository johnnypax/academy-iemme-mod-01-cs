using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_lerz09_contatti_CF.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoIndirizzo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Indirizzo",
                table: "Contattos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Indirizzo",
                table: "Contattos");
        }
    }
}
