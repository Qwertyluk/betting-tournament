using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_BettingGames_GameId",
                table: "ArchivedBets");

            migrationBuilder.AddColumn<bool>(
                name: "ScoreAssigned",
                table: "ArchivedGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_ArchivedGames_GameId",
                table: "ArchivedBets",
                column: "GameId",
                principalTable: "ArchivedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_ArchivedGames_GameId",
                table: "ArchivedBets");

            migrationBuilder.DropColumn(
                name: "ScoreAssigned",
                table: "ArchivedGames");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_BettingGames_GameId",
                table: "ArchivedBets",
                column: "GameId",
                principalTable: "BettingGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
