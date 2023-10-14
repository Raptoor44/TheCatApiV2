using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutcléétrangèredelaracesurlentitéPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BreedId",
                table: "PicturesDatabaseModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdBreed",
                table: "PicturesDatabaseModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PicturesDatabaseModel_BreedId",
                table: "PicturesDatabaseModel",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel",
                column: "BreedId",
                principalTable: "BreedsDatabaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicturesDatabaseModel_BreedsDatabaseModel_BreedId",
                table: "PicturesDatabaseModel");

            migrationBuilder.DropIndex(
                name: "IX_PicturesDatabaseModel_BreedId",
                table: "PicturesDatabaseModel");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "PicturesDatabaseModel");

            migrationBuilder.DropColumn(
                name: "IdBreed",
                table: "PicturesDatabaseModel");
        }
    }
}
