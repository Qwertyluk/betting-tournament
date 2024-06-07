using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingTournament.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets");

            migrationBuilder.RenameColumn(
                name: "HomeScore",
                table: "ArchivedBets",
                newName: "HomeBetScore");

            migrationBuilder.RenameColumn(
                name: "AwayScore",
                table: "ArchivedBets",
                newName: "AwayBetScore");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ArchivedBets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets");

            migrationBuilder.RenameColumn(
                name: "HomeBetScore",
                table: "ArchivedBets",
                newName: "HomeScore");

            migrationBuilder.RenameColumn(
                name: "AwayBetScore",
                table: "ArchivedBets",
                newName: "AwayScore");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ArchivedBets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivedBets_AspNetUsers_ApplicationUserId",
                table: "ArchivedBets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
