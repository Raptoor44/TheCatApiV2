using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdesracesdanslabasededonnées : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureJoinedDatabaseModels_AspNetUsers_UserId",
                table: "PictureJoinedDatabaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureJoinedDatabaseModels_PicturesDatabaseModel_PictureId",
                table: "PictureJoinedDatabaseModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PictureJoinedDatabaseModels",
                table: "PictureJoinedDatabaseModels");

            migrationBuilder.RenameTable(
                name: "PictureJoinedDatabaseModels",
                newName: "PicturesJoinedDatabaseModels");

            migrationBuilder.RenameIndex(
                name: "IX_PictureJoinedDatabaseModels_UserId",
                table: "PicturesJoinedDatabaseModels",
                newName: "IX_PicturesJoinedDatabaseModels_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PictureJoinedDatabaseModels_PictureId",
                table: "PicturesJoinedDatabaseModels",
                newName: "IX_PicturesJoinedDatabaseModels_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PicturesJoinedDatabaseModels",
                table: "PicturesJoinedDatabaseModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imperial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedsDatabaseModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CfaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VetstreetUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcahospitalsUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCodes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeSpan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indoor = table.Column<int>(type: "int", nullable: false),
                    Lap = table.Column<int>(type: "int", nullable: false),
                    AltNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adaptability = table.Column<int>(type: "int", nullable: false),
                    AffectionLevel = table.Column<int>(type: "int", nullable: false),
                    ChildFriendly = table.Column<int>(type: "int", nullable: false),
                    DogFriendly = table.Column<int>(type: "int", nullable: false),
                    EnergyLevel = table.Column<int>(type: "int", nullable: false),
                    Grooming = table.Column<int>(type: "int", nullable: false),
                    HealthIssues = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    SheddingLevel = table.Column<int>(type: "int", nullable: false),
                    SocialNeeds = table.Column<int>(type: "int", nullable: false),
                    StrangerFriendly = table.Column<int>(type: "int", nullable: false),
                    Vocalisation = table.Column<int>(type: "int", nullable: false),
                    Experimental = table.Column<int>(type: "int", nullable: false),
                    Hairless = table.Column<int>(type: "int", nullable: false),
                    Natural = table.Column<int>(type: "int", nullable: false),
                    Rare = table.Column<int>(type: "int", nullable: false),
                    Rex = table.Column<int>(type: "int", nullable: false),
                    SuppressedTail = table.Column<int>(type: "int", nullable: false),
                    ShortLegs = table.Column<int>(type: "int", nullable: false),
                    WikipediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hypoallergenic = table.Column<int>(type: "int", nullable: false),
                    ReferenceImageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatWeightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedsDatabaseModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedsDatabaseModel_Weight_CatWeightId",
                        column: x => x.CatWeightId,
                        principalTable: "Weight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedsDatabaseModel_CatWeightId",
                table: "BreedsDatabaseModel",
                column: "CatWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_PicturesJoinedDatabaseModels_AspNetUsers_UserId",
                table: "PicturesJoinedDatabaseModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PicturesJoinedDatabaseModels_PicturesDatabaseModel_PictureId",
                table: "PicturesJoinedDatabaseModels",
                column: "PictureId",
                principalTable: "PicturesDatabaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicturesJoinedDatabaseModels_AspNetUsers_UserId",
                table: "PicturesJoinedDatabaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PicturesJoinedDatabaseModels_PicturesDatabaseModel_PictureId",
                table: "PicturesJoinedDatabaseModels");

            migrationBuilder.DropTable(
                name: "BreedsDatabaseModel");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PicturesJoinedDatabaseModels",
                table: "PicturesJoinedDatabaseModels");

            migrationBuilder.RenameTable(
                name: "PicturesJoinedDatabaseModels",
                newName: "PictureJoinedDatabaseModels");

            migrationBuilder.RenameIndex(
                name: "IX_PicturesJoinedDatabaseModels_UserId",
                table: "PictureJoinedDatabaseModels",
                newName: "IX_PictureJoinedDatabaseModels_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PicturesJoinedDatabaseModels_PictureId",
                table: "PictureJoinedDatabaseModels",
                newName: "IX_PictureJoinedDatabaseModels_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PictureJoinedDatabaseModels",
                table: "PictureJoinedDatabaseModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PictureJoinedDatabaseModels_AspNetUsers_UserId",
                table: "PictureJoinedDatabaseModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PictureJoinedDatabaseModels_PicturesDatabaseModel_PictureId",
                table: "PictureJoinedDatabaseModels",
                column: "PictureId",
                principalTable: "PicturesDatabaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
