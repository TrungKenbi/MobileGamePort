using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileGamePort.Migrations
{
    public partial class AddTableGiftUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Downloads",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkAndroid",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkIOS",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Downloads",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LinkAndroid",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LinkIOS",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Games");
        }
    }
}
