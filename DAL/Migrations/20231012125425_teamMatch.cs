using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class teamMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamID",
                table: "Matches",
                column: "AwayTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_teams_AwayTeamID",
                table: "Matches",
                column: "AwayTeamID",
                principalTable: "teams",
                principalColumn: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_teams_AwayTeamID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayTeamID",
                table: "Matches");
        }
    }
}
