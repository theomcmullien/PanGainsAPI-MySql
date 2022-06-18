using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanGainsAPI.Migrations
{
    public partial class AddToLeaderboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChallengesID",
                table: "Leaderboard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengesID",
                table: "Leaderboard");
        }
    }
}
