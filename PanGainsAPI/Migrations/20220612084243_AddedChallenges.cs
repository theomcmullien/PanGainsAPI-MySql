using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanGainsAPI.Migrations
{
    public partial class AddedChallenges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChallengeID",
                table: "Challenges",
                newName: "ChallengesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChallengesID",
                table: "Challenges",
                newName: "ChallengeID");
        }
    }
}
