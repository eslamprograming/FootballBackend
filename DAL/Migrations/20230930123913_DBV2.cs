using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class DBV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamName",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamID",
                table: "Matches",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamID",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeamName",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
