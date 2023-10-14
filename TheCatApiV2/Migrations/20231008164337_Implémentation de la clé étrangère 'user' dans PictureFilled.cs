using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ImplémentationdelacléétrangèreuserdansPictureFilled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PictureFilledDatabaseModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PictureFilledDatabaseModels_UserId",
                table: "PictureFilledDatabaseModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PictureFilledDatabaseModels_AspNetUsers_UserId",
                table: "PictureFilledDatabaseModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureFilledDatabaseModels_AspNetUsers_UserId",
                table: "PictureFilledDatabaseModels");

            migrationBuilder.DropIndex(
                name: "IX_PictureFilledDatabaseModels_UserId",
                table: "PictureFilledDatabaseModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PictureFilledDatabaseModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
