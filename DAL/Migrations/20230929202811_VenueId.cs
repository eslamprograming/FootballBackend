using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class VenueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Venues_VenueID",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Matches",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_VenueID",
                table: "Matches",
                newName: "IX_Matches_VenueId");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Venues_VenueId",
                table: "Matches",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Venues_VenueId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Matches",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_VenueId",
                table: "Matches",
                newName: "IX_Matches_VenueID");

            migrationBuilder.AlterColumn<int>(
                name: "VenueID",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Venues_VenueID",
                table: "Matches",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueID");
        }
    }
}
