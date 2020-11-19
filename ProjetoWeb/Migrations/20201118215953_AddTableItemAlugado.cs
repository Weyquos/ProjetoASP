﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AddTableItemAlugado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensAlugados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    LivroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensAlugados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensAlugados_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensAlugados_LivroId",
                table: "ItensAlugados",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensAlugados");
        }
    }
}
