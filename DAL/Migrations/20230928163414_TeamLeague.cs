using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class TeamLeague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueID",
                table: "teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teams_LeagueID",
                table: "teams",
                column: "LeagueID");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_Leagues_LeagueID",
                table: "teams",
                column: "LeagueID",
                principalTable: "Leagues",
                principalColumn: "LeagueID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_Leagues_LeagueID",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_LeagueID",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "LeagueID",
                table: "teams");
        }
    }
}
