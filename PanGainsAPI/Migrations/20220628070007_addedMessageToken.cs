using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanGainsAPI.Migrations
{
    public partial class addedMessageToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageToken",
                table: "Account",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageToken",
                table: "Account");
        }
    }
}
