using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMovie.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieDbs",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDbMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDbs", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_MovieDbs_MovieDbs_MovieDbMovieId",
                        column: x => x.MovieDbMovieId,
                        principalTable: "MovieDbs",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewDbs",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieDbMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewDbs", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewDbs_MovieDbs_MovieDbMovieId",
                        column: x => x.MovieDbMovieId,
                        principalTable: "MovieDbs",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDbs_MovieDbMovieId",
                table: "MovieDbs",
                column: "MovieDbMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDbs_MovieDbMovieId",
                table: "ReviewDbs",
                column: "MovieDbMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewDbs");

            migrationBuilder.DropTable(
                name: "MovieDbs");
        }
    }
}
