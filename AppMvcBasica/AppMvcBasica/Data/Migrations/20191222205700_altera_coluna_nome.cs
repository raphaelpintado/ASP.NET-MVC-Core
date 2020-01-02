using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMvcBasica.Data.Migrations
{
    public partial class altera_coluna_nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nomne",
                table: "Produtos",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produtos",
                newName: "Nomne");
        }
    }
}
