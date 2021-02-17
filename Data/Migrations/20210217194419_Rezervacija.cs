using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace knjiznica.Data.Migrations
{
    public partial class Rezervacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnjigaId = table.Column<int>(nullable: false),
                    datumRezervacija = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Knjiga_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KnjigaId",
                table: "Rezervacija",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UserId",
                table: "Rezervacija",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");
        }
    }
}
