using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenamingMinAMount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAMount",
                table: "Coupons",
                newName: "MinimumAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimumAmount",
                table: "Coupons",
                newName: "MinAMount");
        }
    }
}
