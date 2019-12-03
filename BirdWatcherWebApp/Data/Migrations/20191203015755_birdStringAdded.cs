using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherWebApp.Data.Migrations
{
    public partial class birdStringAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bird",
                table: "spotted",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bird",
                table: "spotted");
        }
    }
}
