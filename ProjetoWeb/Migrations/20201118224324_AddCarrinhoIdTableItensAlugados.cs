using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AddCarrinhoIdTableItensAlugados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrinhoId",
                table: "ItensAlugados",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "ItensAlugados");
        }
    }
}
