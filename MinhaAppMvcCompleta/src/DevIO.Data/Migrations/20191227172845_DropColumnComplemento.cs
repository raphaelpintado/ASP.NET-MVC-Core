using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class DropColumnComplemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Enderecos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
