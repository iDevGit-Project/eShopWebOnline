using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_MakeTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_FAQAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_FAQAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Products_TBL_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "TBL_Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Products_TBL_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TBL_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyValueId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperties_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductGalleries_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SpecialPrice = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MaxOrderCount = table.Column<int>(type: "int", nullable: true),
                    SubmitDate = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    GuaranteeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    StartDisCount = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDisCount = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPrices_TBL_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "TBL_Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPrices_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ProductPrices_TBL_Warranties_GuaranteeId",
                        column: x => x.GuaranteeId,
                        principalTable: "TBL_Warranties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductQuestions_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Positive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Negative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductReviews_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductGalleries_ProductId",
                table: "TBL_ProductGalleries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPrices_ColorId",
                table: "TBL_ProductPrices",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPrices_GuaranteeId",
                table: "TBL_ProductPrices",
                column: "GuaranteeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductPrices_ProductId",
                table: "TBL_ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductQuestions_ProductId",
                table: "TBL_ProductQuestions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductReviews_ProductId",
                table: "TBL_ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Products_BrandId",
                table: "TBL_Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Products_CategoryId",
                table: "TBL_Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "TBL_FAQAnswers");

            migrationBuilder.DropTable(
                name: "TBL_ProductGalleries");

            migrationBuilder.DropTable(
                name: "TBL_ProductPrices");

            migrationBuilder.DropTable(
                name: "TBL_ProductQuestions");

            migrationBuilder.DropTable(
                name: "TBL_ProductReviews");

            migrationBuilder.DropTable(
                name: "TBL_Products");
        }
    }
}
