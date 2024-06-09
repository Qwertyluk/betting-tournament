using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AwayTeamBet",
                table: "ActiveBets",
                newName: "Test");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "ActiveBets",
                newName: "AwayTeamBet");
        }
    }
}
