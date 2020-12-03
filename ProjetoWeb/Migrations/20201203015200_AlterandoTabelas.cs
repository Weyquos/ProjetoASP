using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AlterandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "ItensAlugados");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensAlugados");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "ItensAlugados",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true),
                    LivroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alugueis_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensAlugados_UsuarioId",
                table: "ItensAlugados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_LivroId",
                table: "Alugueis",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_UsuarioId",
                table: "Alugueis",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensAlugados_AspNetUsers_UsuarioId",
                table: "ItensAlugados",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensAlugados_AspNetUsers_UsuarioId",
                table: "ItensAlugados");

            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropIndex(
                name: "IX_ItensAlugados_UsuarioId",
                table: "ItensAlugados");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ItensAlugados");

            migrationBuilder.AddColumn<string>(
                name: "CarrinhoId",
                table: "ItensAlugados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItensAlugados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
