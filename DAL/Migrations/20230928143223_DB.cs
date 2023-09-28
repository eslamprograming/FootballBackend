using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueID);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedYear = table.Column<int>(type: "int", nullable: false),
                    HomeCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeStadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShirtNumber = table.Column<int>(type: "int", nullable: false),
                    CurrentTeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_teams_CurrentTeamID",
                        column: x => x.CurrentTeamID,
                        principalTable: "teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    StandingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GoalsFor = table.Column<int>(type: "int", nullable: false),
                    GoalsAgainst = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.StandingID);
                    table.ForeignKey(
                        name: "FK_Standings_Leagues_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "Leagues",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standings_teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamID = table.Column<int>(type: "int", nullable: false),
                    AwayTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefereeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueID = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_Leagues_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "Leagues",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_teams_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamID",
                table: "Matches",
                column: "HomeTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LeagueID",
                table: "Matches",
                column: "LeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VenueID",
                table: "Matches",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentTeamID",
                table: "Players",
                column: "CurrentTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_LeagueID",
                table: "Standings",
                column: "LeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TeamID",
                table: "Standings",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
