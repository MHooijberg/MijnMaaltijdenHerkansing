using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MijnMaaltijdenHerkansing.Migrations
{
    public partial class BasicScaffolding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Huisnummer = table.Column<int>(type: "int", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.AdresId);
                });

            migrationBuilder.CreateTable(
                name: "Maaltijden",
                columns: table => new
                {
                    MaaltijdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredienten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVegatarisch = table.Column<bool>(type: "bit", nullable: false),
                    Afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maaltijden", x => x.MaaltijdId);
                    table.ForeignKey(
                        name: "FK_Maaltijden_AspNetUsers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBevroren = table.Column<bool>(type: "bit", nullable: false),
                    BereidOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoudbaarheidsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    aantalPorties = table.Column<int>(type: "int", nullable: false),
                    Waardering = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaaltijdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Maaltijden_MaaltijdId",
                        column: x => x.MaaltijdId,
                        principalTable: "Maaltijden",
                        principalColumn: "MaaltijdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdresId",
                table: "AspNetUsers",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Maaltijden_GebruikerId",
                table: "Maaltijden",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GebruikerId",
                table: "Posts",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MaaltijdId",
                table: "Posts",
                column: "MaaltijdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adressen_AdresId",
                table: "AspNetUsers",
                column: "AdresId",
                principalTable: "Adressen",
                principalColumn: "AdresId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adressen_AdresId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Maaltijden");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdresId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
