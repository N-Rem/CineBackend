using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNational = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chad Stahelski" },
                    { 2, "Tim Miller" },
                    { 3, "Jon Watts" },
                    { 4, "Juan José Campanella" },
                    { 5, "Damián Szifron" },
                    { 6, "Fabián Bielinsky" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "ImageUrl", "IsNational", "Title" },
                values: new object[,]
                {
                    { 1, "Un asesino a sueldo sale de su retiro para vengarse de los que le hicieron daño.", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlMhuTYAKZHxZXA4OzjqcKaopJEjTOzLxnQ&s", false, "John Wick" },
                    { 2, "Un mercenario con habilidades de curación acelerada busca venganza.", 2, "https://pics.filmaffinity.com/Deadpool-834516798-mmed.jpg", false, "Deadpool" },
                    { 3, "Un joven adquiere habilidades arácnidas después de ser mordido por una araña radioactiva.", 3, "https://hips.hearstapps.com/hmg-prod/images/spiderman-homecoming-poster-1551691492.jpg", false, "Spiderman" },
                    { 4, "Un ex funcionario judicial decide escribir una novela basada en un caso real que lo afectó profundamente.", 4, "https://m.media-amazon.com/images/I/61dlTXqaMLL._AC_SL1024_.jpg", true, "El secreto de sus ojos" },
                    { 5, "Una serie de seis cortometrajes que exploran la violencia y la venganza en diferentes formas.", 5, "https://pics.filmaffinity.com/relatos_salvajes-285164385-large.jpg", true, "Relatos salvajes" },
                    { 6, "Dos estafadores intentan vender una serie de sellos falsos extremadamente valiosos.", 6, "https://m.media-amazon.com/images/I/71aA-cKYcWL._AC_SL1500_.jpg", true, "Nueve reinas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
