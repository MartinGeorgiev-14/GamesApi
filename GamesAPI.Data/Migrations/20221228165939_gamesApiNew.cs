using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Data.Migrations
{
    public partial class gamesApiNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NA_Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EU_Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JP_Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Other_Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    GenreModelId = table.Column<int>(type: "int", nullable: false),
                    PublisherModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesModels_GenreModels_GenreModelId",
                        column: x => x.GenreModelId,
                        principalTable: "GenreModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModels_PublisherModels_PublisherModelId",
                        column: x => x.PublisherModelId,
                        principalTable: "PublisherModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModels_YearModels_YearId",
                        column: x => x.YearId,
                        principalTable: "YearModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesPlatformMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamesModelId = table.Column<int>(type: "int", nullable: false),
                    PlatformModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesPlatformMTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesPlatformMTMs_GamesModels_GamesModelId",
                        column: x => x.GamesModelId,
                        principalTable: "GamesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesPlatformMTMs_PlatformModels_PlatformModelId",
                        column: x => x.PlatformModelId,
                        principalTable: "PlatformModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesModels_GenreModelId",
                table: "GamesModels",
                column: "GenreModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModels_PublisherModelId",
                table: "GamesModels",
                column: "PublisherModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModels_YearId",
                table: "GamesModels",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlatformMTMs_GamesModelId",
                table: "GamesPlatformMTMs",
                column: "GamesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlatformMTMs_PlatformModelId",
                table: "GamesPlatformMTMs",
                column: "PlatformModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesPlatformMTMs");

            migrationBuilder.DropTable(
                name: "GamesModels");

            migrationBuilder.DropTable(
                name: "PlatformModels");

            migrationBuilder.DropTable(
                name: "GenreModels");

            migrationBuilder.DropTable(
                name: "PublisherModels");

            migrationBuilder.DropTable(
                name: "YearModels");
        }
    }
}
