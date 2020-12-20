using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileGamePort.Migrations
{
    public partial class ModifyTableNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedAt",
                table: "News",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
