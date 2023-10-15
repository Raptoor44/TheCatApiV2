using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class EnlèvementdelattributisFavoritedansPictureJoinedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "PicturesJoinedDatabaseModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "PicturesJoinedDatabaseModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
