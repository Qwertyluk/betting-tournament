using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_ApplicationUserId",
                table: "Bets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_ApplicationUserId",
                table: "Bets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_ApplicationUserId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_ApplicationUserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
