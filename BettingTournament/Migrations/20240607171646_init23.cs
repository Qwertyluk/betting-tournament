using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeBetScore",
                table: "ArchivedBets",
                newName: "HomeTeamBet");

            migrationBuilder.RenameColumn(
                name: "AwayBetScore",
                table: "ArchivedBets",
                newName: "AwayTeamBet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamBet",
                table: "ArchivedBets",
                newName: "HomeBetScore");

            migrationBuilder.RenameColumn(
                name: "AwayTeamBet",
                table: "ArchivedBets",
                newName: "AwayBetScore");
        }
    }
}
