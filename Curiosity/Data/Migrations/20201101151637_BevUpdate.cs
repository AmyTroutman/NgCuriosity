using Microsoft.EntityFrameworkCore.Migrations;

namespace Curiosity.Data.Migrations
{
    public partial class BevUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Caffeine",
                table: "HotBevs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HotBevs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caffeine",
                table: "HotBevs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HotBevs");
        }
    }
}
