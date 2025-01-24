using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFKFromSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AlbumID",
                table: "Songs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumID",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
