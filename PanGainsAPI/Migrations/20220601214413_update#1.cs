using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanGainsAPI.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Account",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Account");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Account",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Account",
                type: "longblob",
                nullable: false);
        }
    }
}
