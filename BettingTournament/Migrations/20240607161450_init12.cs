using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_Games_GameId",
                table: "ArchivedBets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ArchivedBets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivedGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeTeam = table.Column<string>(type: "TEXT", nullable: false),
                    AwayTeam = table.Column<string>(type: "TEXT", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTimeUTC = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BettingGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeTeam = table.Column<string>(type: "TEXT", nullable: false),
                    AwayTeam = table.Column<string>(type: "TEXT", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTimeUTC = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingGames", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_BettingGames_GameId",
                table: "ArchivedBets",
                column: "GameId",
                principalTable: "BettingGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_BettingGames_GameId",
                table: "Bets",
                column: "GameId",
                principalTable: "BettingGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_BettingGames_GameId",
                table: "ArchivedBets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_BettingGames_GameId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "ArchivedGames");

            migrationBuilder.DropTable(
                name: "BettingGames");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ArchivedBets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AwayScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeam = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeUTC = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HomeScore = table.Column<int>(type: "INTEGER", nullable: false),
                    HomeTeam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_Games_GameId",
                table: "ArchivedBets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
