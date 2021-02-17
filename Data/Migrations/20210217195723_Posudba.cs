using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace knjiznica.Data.Migrations
{
    public partial class Posudba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posudba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    KnjigaId = table.Column<int>(nullable: false),
                    datumPosudbe = table.Column<DateTime>(nullable: false),
                    datumVraćanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posudba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posudba_Knjiga_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posudba_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posudba_KnjigaId",
                table: "Posudba",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posudba_UserId",
                table: "Posudba",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posudba");
        }
    }
}
