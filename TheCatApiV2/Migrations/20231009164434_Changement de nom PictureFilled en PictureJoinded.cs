using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ChangementdenomPictureFilledenPictureJoinded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureFilledDatabaseModels");

            migrationBuilder.CreateTable(
                name: "PictureJoinedDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPicture = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureJoinedDatabaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureJoinedDatabaseModels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureJoinedDatabaseModels_PicturesDatabaseModel_PictureId",
                        column: x => x.PictureId,
                        principalTable: "PicturesDatabaseModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureJoinedDatabaseModels_PictureId",
                table: "PictureJoinedDatabaseModels",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureJoinedDatabaseModels_UserId",
                table: "PictureJoinedDatabaseModels",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureJoinedDatabaseModels");

            migrationBuilder.CreateTable(
                name: "PictureFilledDatabaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPicture = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureFilledDatabaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureFilledDatabaseModels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureFilledDatabaseModels_PicturesDatabaseModel_PictureId",
                        column: x => x.PictureId,
                        principalTable: "PicturesDatabaseModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureFilledDatabaseModels_PictureId",
                table: "PictureFilledDatabaseModels",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureFilledDatabaseModels_UserId",
                table: "PictureFilledDatabaseModels",
                column: "UserId");
        }
    }
}
