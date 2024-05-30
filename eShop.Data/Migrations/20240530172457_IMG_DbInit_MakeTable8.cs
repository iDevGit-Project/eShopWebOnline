using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_MakeTable8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_TBL_Products_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties");

            migrationBuilder.RenameTable(
                name: "ProductProperties",
                newName: "TBL_ProductProperties");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProperties_PropertyValueId",
                table: "TBL_ProductProperties",
                newName: "IX_TBL_ProductProperties_PropertyValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProperties_ProductId",
                table: "TBL_ProductProperties",
                newName: "IX_TBL_ProductProperties_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBL_ProductProperties",
                table: "TBL_ProductProperties",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TBL_DisCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDisCount = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDisCount = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DisCounts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "TBL_ProductProperties",
                column: "PropertyValueId",
                principalTable: "TBL_ProductPropertyValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductProperties_TBL_Products_ProductId",
                table: "TBL_ProductProperties",
                column: "ProductId",
                principalTable: "TBL_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "TBL_ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductProperties_TBL_Products_ProductId",
                table: "TBL_ProductProperties");

            migrationBuilder.DropTable(
                name: "TBL_DisCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBL_ProductProperties",
                table: "TBL_ProductProperties");

            migrationBuilder.RenameTable(
                name: "TBL_ProductProperties",
                newName: "ProductProperties");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_ProductProperties_PropertyValueId",
                table: "ProductProperties",
                newName: "IX_ProductProperties_PropertyValueId");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_ProductProperties_ProductId",
                table: "ProductProperties",
                newName: "IX_ProductProperties_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "ProductProperties",
                column: "PropertyValueId",
                principalTable: "TBL_ProductPropertyValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_TBL_Products_ProductId",
                table: "ProductProperties",
                column: "ProductId",
                principalTable: "TBL_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
