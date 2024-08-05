using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMG_DbInit_patch2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "TBL_Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "TBL_Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImgName",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DesCripton",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductQuestions_UserId",
                table: "TBL_ProductQuestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FAQAnswers_QuestionId",
                table: "TBL_FAQAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FAQAnswers_UserId",
                table: "TBL_FAQAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_FAQAnswers_TBL_ProductQuestions_QuestionId",
                table: "TBL_FAQAnswers",
                column: "QuestionId",
                principalTable: "TBL_ProductQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_FAQAnswers_TBL_Users_UserId",
                table: "TBL_FAQAnswers",
                column: "UserId",
                principalTable: "TBL_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductQuestions_TBL_Users_UserId",
                table: "TBL_ProductQuestions",
                column: "UserId",
                principalTable: "TBL_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_FAQAnswers_TBL_ProductQuestions_QuestionId",
                table: "TBL_FAQAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_FAQAnswers_TBL_Users_UserId",
                table: "TBL_FAQAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductQuestions_TBL_Users_UserId",
                table: "TBL_ProductQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ProductQuestions_UserId",
                table: "TBL_ProductQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TBL_FAQAnswers_QuestionId",
                table: "TBL_FAQAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TBL_FAQAnswers_UserId",
                table: "TBL_FAQAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "TBL_Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "TBL_Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImgName",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesCripton",
                table: "TBL_Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
