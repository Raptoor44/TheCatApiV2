using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ChangementIdPictureenPictureIddansPictureJoinedDatabaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPicture",
                table: "PicturesJoinedDatabaseModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPicture",
                table: "PicturesJoinedDatabaseModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
