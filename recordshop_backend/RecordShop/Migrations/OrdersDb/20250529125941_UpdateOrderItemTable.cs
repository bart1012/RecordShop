using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Backend.Migrations.OrdersDb
{
    /// <inheritdoc />
    public partial class UpdateOrderItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "AlbumArtist",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AlbumTitle",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AlbumArtist",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AlbumTitle",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");
        }
    }
}
