using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherWebApp.Data.Migrations
{
    public partial class spottedsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "spotted",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "spotted",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "longitude",
                table: "spotted",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "latitude",
                table: "spotted",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
