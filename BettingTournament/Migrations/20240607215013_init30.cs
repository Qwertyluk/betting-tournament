using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeScore",
                table: "ActiveBets",
                newName: "HomeTeamBet");

            migrationBuilder.RenameColumn(
                name: "AwayScore",
                table: "ActiveBets",
                newName: "AwayTeamBet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamBet",
                table: "ActiveBets",
                newName: "HomeScore");

            migrationBuilder.RenameColumn(
                name: "AwayTeamBet",
                table: "ActiveBets",
                newName: "AwayScore");
        }
    }
}
