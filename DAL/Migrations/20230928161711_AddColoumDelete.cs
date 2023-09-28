using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddColoumDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Venues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Standings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Leagues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Leagues");
        }
    }
}
