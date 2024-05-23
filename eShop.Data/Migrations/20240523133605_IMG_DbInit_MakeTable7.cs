using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_MakeTable7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ProductPropertyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductPropertyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductPropertyNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductPropertyNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPropertyNames_TBL_ProductPropertyGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "TBL_ProductPropertyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductPropertyNameCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductPropertyNameCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPropertyNameCategories_TBL_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TBL_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPropertyNameCategories_TBL_ProductPropertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "TBL_ProductPropertyNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductPropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPropertyValues_TBL_ProductPropertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "TBL_ProductPropertyNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PropertyValueId",
                table: "ProductProperties",
                column: "PropertyValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPropertyNameCategories_CategoryId",
                table: "TBL_ProductPropertyNameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPropertyNameCategories_PropertyNameId",
                table: "TBL_ProductPropertyNameCategories",
                column: "PropertyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPropertyNames_GroupId",
                table: "TBL_ProductPropertyNames",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPropertyValues_PropertyNameId",
                table: "TBL_ProductPropertyValues",
                column: "PropertyNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "ProductProperties",
                column: "PropertyValueId",
                principalTable: "TBL_ProductPropertyValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                table: "ProductProperties");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyNameCategories");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyValues");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyNames");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyGroups");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_PropertyValueId",
                table: "ProductProperties");
        }
    }
}
