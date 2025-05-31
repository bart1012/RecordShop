using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Backend.Migrations.OrdersDb
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountPence",
                table: "Orders",
                newName: "TotalPence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPence",
                table: "Orders",
                newName: "AmountPence");
        }
    }
}
