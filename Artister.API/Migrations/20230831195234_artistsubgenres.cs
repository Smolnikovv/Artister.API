using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artister.API.Migrations
{
    /// <inheritdoc />
    public partial class artistsubgenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subgenres_Artists_ArtistId",
                table: "Subgenres");

            migrationBuilder.DropIndex(
                name: "IX_Subgenres_ArtistId",
                table: "Subgenres");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Subgenres");

            migrationBuilder.CreateTable(
                name: "ArtistsSubgenres",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SubgenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsSubgenres");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Subgenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subgenres_ArtistId",
                table: "Subgenres",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subgenres_Artists_ArtistId",
                table: "Subgenres",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
