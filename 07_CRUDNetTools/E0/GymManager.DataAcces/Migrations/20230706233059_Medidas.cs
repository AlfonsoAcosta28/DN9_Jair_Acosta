using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.DataAcces.Migrations
{
    public partial class Medidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "EquipmentType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "EquipmentType");
        }
    }
}
