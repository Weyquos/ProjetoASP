using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AddQuantidadeTableItensAlugados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItensAlugados",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensAlugados");
        }
    }
}
