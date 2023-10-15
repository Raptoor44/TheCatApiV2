using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutdelattributisLikedetisValikeddansPictureJoinedDatabaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBadLike",
                table: "PicturesJoinedDatabaseModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLiked",
                table: "PicturesJoinedDatabaseModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBadLike",
                table: "PicturesJoinedDatabaseModels");

            migrationBuilder.DropColumn(
                name: "isLiked",
                table: "PicturesJoinedDatabaseModels");
        }
    }
}
