using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_MakeTable8_patch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ProductCartTBL_ProductCartDetail");

            migrationBuilder.CreateTable(
                name: "TBL_PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Athourity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisCountId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PaymentDetails_TBL_DisCounts_DisCountId",
                        column: x => x.DisCountId,
                        principalTable: "TBL_DisCounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_PaymentDetails_TBL_ProductCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "TBL_ProductCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductCartDetails_CartId",
                table: "TBL_ProductCartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PaymentDetails_CartId",
                table: "TBL_PaymentDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PaymentDetails_DisCountId",
                table: "TBL_PaymentDetails",
                column: "DisCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductCartDetails_TBL_ProductCarts_CartId",
                table: "TBL_ProductCartDetails",
                column: "CartId",
                principalTable: "TBL_ProductCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductCartDetails_TBL_ProductCarts_CartId",
                table: "TBL_ProductCartDetails");

            migrationBuilder.DropTable(
                name: "TBL_PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ProductCartDetails_CartId",
                table: "TBL_ProductCartDetails");

            migrationBuilder.CreateTable(
                name: "TBL_ProductCartTBL_ProductCartDetail",
                columns: table => new
                {
                    TBLProductCartDetailsId = table.Column<int>(type: "int", nullable: false),
                    TBLProductCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductCartTBL_ProductCartDetail", x => new { x.TBLProductCartDetailsId, x.TBLProductCartsId });
                    table.ForeignKey(
                        name: "FK_TBL_ProductCartTBL_ProductCartDetail_TBL_ProductCartDetails_TBLProductCartDetailsId",
                        column: x => x.TBLProductCartDetailsId,
                        principalTable: "TBL_ProductCartDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ProductCartTBL_ProductCartDetail_TBL_ProductCarts_TBLProductCartsId",
                        column: x => x.TBLProductCartsId,
                        principalTable: "TBL_ProductCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductCartTBL_ProductCartDetail_TBLProductCartsId",
                table: "TBL_ProductCartTBL_ProductCartDetail",
                column: "TBLProductCartsId");
        }
    }
}
