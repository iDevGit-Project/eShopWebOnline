using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_patch4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisCountId",
                table: "TBL_ProductCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "TBL_ProductCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalBarcode",
                table: "TBL_ProductCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentCode",
                table: "TBL_ProductCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingCost",
                table: "TBL_ProductCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "FirstOrder",
                table: "TBL_DisCounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreeShipping",
                table: "TBL_DisCounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPercentage",
                table: "TBL_DisCounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "TBL_DisCounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductCarts_DisCountId",
                table: "TBL_ProductCarts",
                column: "DisCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductCarts_TBL_DisCounts_DisCountId",
                table: "TBL_ProductCarts",
                column: "DisCountId",
                principalTable: "TBL_DisCounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductCarts_TBL_DisCounts_DisCountId",
                table: "TBL_ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ProductCarts_DisCountId",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "DisCountId",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "PostalBarcode",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "ShipmentCode",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "ShippingCost",
                table: "TBL_ProductCarts");

            migrationBuilder.DropColumn(
                name: "FirstOrder",
                table: "TBL_DisCounts");

            migrationBuilder.DropColumn(
                name: "FreeShipping",
                table: "TBL_DisCounts");

            migrationBuilder.DropColumn(
                name: "IsPercentage",
                table: "TBL_DisCounts");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "TBL_DisCounts");
        }
    }
}
