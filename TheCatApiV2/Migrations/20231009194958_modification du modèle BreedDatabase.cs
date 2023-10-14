using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCatApiV2.Migrations
{
    /// <inheritdoc />
    public partial class modificationdumodèleBreedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedsDatabaseModel_Weight_CatWeightId",
                table: "BreedsDatabaseModel");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropIndex(
                name: "IX_BreedsDatabaseModel_CatWeightId",
                table: "BreedsDatabaseModel");

            migrationBuilder.AddColumn<string>(
                name: "Imperial",
                table: "BreedsDatabaseModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Metric",
                table: "BreedsDatabaseModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imperial",
                table: "BreedsDatabaseModel");

            migrationBuilder.DropColumn(
                name: "Metric",
                table: "BreedsDatabaseModel");

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

            migrationBuilder.CreateIndex(
                name: "IX_BreedsDatabaseModel_CatWeightId",
                table: "BreedsDatabaseModel",
                column: "CatWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedsDatabaseModel_Weight_CatWeightId",
                table: "BreedsDatabaseModel",
                column: "CatWeightId",
                principalTable: "Weight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
