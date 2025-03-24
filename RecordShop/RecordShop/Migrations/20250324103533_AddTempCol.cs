using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTempCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempCol",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempCol",
                table: "Genres");
        }
    }
}
