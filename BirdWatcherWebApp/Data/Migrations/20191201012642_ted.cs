using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherWebApp.Data.Migrations
{
    public partial class ted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bird",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spotted",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotterId = table.Column<int>(nullable: true),
                    SpottedBirdId = table.Column<int>(nullable: true),
                    QuantitySpotted = table.Column<int>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    latitutde = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spotted", x => x.id);
                    table.ForeignKey(
                        name: "FK_spotted_Bird_SpottedBirdId",
                        column: x => x.SpottedBirdId,
                        principalTable: "Bird",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spotted_User_SpotterId",
                        column: x => x.SpotterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spotted_SpottedBirdId",
                table: "spotted",
                column: "SpottedBirdId");

            migrationBuilder.CreateIndex(
                name: "IX_spotted_SpotterId",
                table: "spotted",
                column: "SpotterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spotted");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
