using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class MiseàjournullablebreeddanslentitéPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel");

            migrationBuilder.AlterColumn<string>(
                name: "IdBreed",
                table: "PicturesDatabaseModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BreedId",
                table: "PicturesDatabaseModel",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel",
                column: "BreedId",
                principalTable: "BreedsDatabaseModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel");

            migrationBuilder.AlterColumn<string>(
                name: "IdBreed",
                table: "PicturesDatabaseModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BreedId",
                table: "PicturesDatabaseModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel",
                column: "BreedId",
                principalTable: "BreedsDatabaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
