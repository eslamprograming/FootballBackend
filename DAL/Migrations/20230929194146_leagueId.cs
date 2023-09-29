using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class leagueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_Leagues_LeagueID",
                table: "teams");

            migrationBuilder.RenameColumn(
                name: "LeagueID",
                table: "teams",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_teams_LeagueID",
                table: "teams",
                newName: "IX_teams_LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_Leagues_LeagueId",
                table: "teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_Leagues_LeagueId",
                table: "teams");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "teams",
                newName: "LeagueID");

            migrationBuilder.RenameIndex(
                name: "IX_teams_LeagueId",
                table: "teams",
                newName: "IX_teams_LeagueID");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_Leagues_LeagueID",
                table: "teams",
                column: "LeagueID",
                principalTable: "Leagues",
                principalColumn: "LeagueID");
        }
    }
}
