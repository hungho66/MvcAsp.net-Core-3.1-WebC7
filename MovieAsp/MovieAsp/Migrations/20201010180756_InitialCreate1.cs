using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAsp.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genreIDID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genreIDID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genreIDID",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genreId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "genreIDID",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreIDID",
                table: "Movies",
                column: "genreIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genreIDID",
                table: "Movies",
                column: "genreIDID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
