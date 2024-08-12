using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    StartTime = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(20)", nullable: false)
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
                    { 3, "Jon Watts" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlMhuTYAKZHxZXA4OzjqcKaopJEjTOzLxnQ&s", "John Wick" },
                    { 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", 2, "https://pics.filmaffinity.com/Deadpool-834516798-mmed.jpg", "Deadpool" },
                    { 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", 3, "https://hips.hearstapps.com/hmg-prod/images/spiderman-homecoming-poster-1551691492.jpg", "Spiderman" }
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
