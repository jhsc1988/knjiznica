using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace knjiznica.Data.Migrations
{
    public partial class Knjiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: false),
                    Izdavac = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knjiga");
        }
    }
}
