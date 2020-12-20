using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileGamePort.Migrations
{
    public partial class AddTableGiftCodeUseVIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScratchCards_Users_UserId",
                table: "ScratchCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScratchCards",
                table: "ScratchCards");

            migrationBuilder.RenameTable(
                name: "ScratchCards",
                newName: "ScratchCard");

            migrationBuilder.RenameIndex(
                name: "IX_ScratchCards_UserId",
                table: "ScratchCard",
                newName: "IX_ScratchCard_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScratchCard",
                table: "ScratchCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScratchCard_Users_UserId",
                table: "ScratchCard",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScratchCard_Users_UserId",
                table: "ScratchCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScratchCard",
                table: "ScratchCard");

            migrationBuilder.RenameTable(
                name: "ScratchCard",
                newName: "ScratchCards");

            migrationBuilder.RenameIndex(
                name: "IX_ScratchCard_UserId",
                table: "ScratchCards",
                newName: "IX_ScratchCards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScratchCards",
                table: "ScratchCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScratchCards_Users_UserId",
                table: "ScratchCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
