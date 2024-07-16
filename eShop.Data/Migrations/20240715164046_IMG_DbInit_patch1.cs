using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_patch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesCripton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Colors", x => x.Id);
                });

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
                name: "TBL_ProductSelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductSelers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<byte>(type: "tinyint", nullable: false),
                    ActiveCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarrantyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Warranties", x => x.Id);
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
                name: "TBL_SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_SubCategories_TBL_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TBL_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_SubCategories_TBL_Categories_SubId",
                        column: x => x.SubId,
                        principalTable: "TBL_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "TBL_ProductCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SumOrder = table.Column<int>(type: "int", nullable: false),
                    OrderType = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductCarts_TBL_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TBL_Users",
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
                        name: "FK_TBL_ProductPrices_TBL_ProductSelers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "TBL_ProductSelers",
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

            migrationBuilder.CreateTable(
                name: "TBL_ProductProperties",
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
                    table.PrimaryKey("PK_TBL_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ProductProperties_TBL_ProductPropertyValues_PropertyValueId",
                        column: x => x.PropertyValueId,
                        principalTable: "TBL_ProductPropertyValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ProductProperties_TBL_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TBL_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PaymentDetails_CartId",
                table: "TBL_PaymentDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PaymentDetails_DisCountId",
                table: "TBL_PaymentDetails",
                column: "DisCountId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductCarts_UserId",
                table: "TBL_ProductCarts",
                column: "UserId");

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
                name: "IX_TBL_ProductPrices_SellerId",
                table: "TBL_ProductPrices",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductProperties_ProductId",
                table: "TBL_ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductProperties_PropertyValueId",
                table: "TBL_ProductProperties",
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

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SubCategories_ParentId",
                table: "TBL_SubCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SubCategories_SubId",
                table: "TBL_SubCategories",
                column: "SubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_FAQAnswers");

            migrationBuilder.DropTable(
                name: "TBL_PaymentDetails");

            migrationBuilder.DropTable(
                name: "TBL_ProductGalleries");

            migrationBuilder.DropTable(
                name: "TBL_ProductPrices");

            migrationBuilder.DropTable(
                name: "TBL_ProductProperties");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyNameCategories");

            migrationBuilder.DropTable(
                name: "TBL_ProductQuestions");

            migrationBuilder.DropTable(
                name: "TBL_ProductReviews");

            migrationBuilder.DropTable(
                name: "TBL_Sliders");

            migrationBuilder.DropTable(
                name: "TBL_SubCategories");

            migrationBuilder.DropTable(
                name: "TBL_DisCounts");

            migrationBuilder.DropTable(
                name: "TBL_ProductCarts");

            migrationBuilder.DropTable(
                name: "TBL_Colors");

            migrationBuilder.DropTable(
                name: "TBL_ProductSelers");

            migrationBuilder.DropTable(
                name: "TBL_Warranties");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyValues");

            migrationBuilder.DropTable(
                name: "TBL_Products");

            migrationBuilder.DropTable(
                name: "TBL_Users");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyNames");

            migrationBuilder.DropTable(
                name: "TBL_Brands");

            migrationBuilder.DropTable(
                name: "TBL_Categories");

            migrationBuilder.DropTable(
                name: "TBL_ProductPropertyGroups");
        }
    }
}
