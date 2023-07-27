using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.DataAcces.Migrations
{
    public partial class Measure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Measure",
                table: "EquipmentType",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measure",
                table: "EquipmentType");
        }
    }
}
