using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddArtistImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Artists");
        }
    }
}
