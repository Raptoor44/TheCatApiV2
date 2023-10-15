using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutdelattributisFavortiedansPictureJoined : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "PicturesJoinedDatabaseModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "PicturesJoinedDatabaseModels");
        }
    }
}
