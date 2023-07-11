using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Example.EntityFramework.Migrations
{
    public partial class MigracionPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventoties_Colors_ColorId",
                table: "Inventoties");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventoties_Vehicles_VehicleId",
                table: "Inventoties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventoties",
                table: "Inventoties");

            migrationBuilder.RenameTable(
                name: "Inventoties",
                newName: "Inventories");

            migrationBuilder.RenameIndex(
                name: "IX_Inventoties_VehicleId",
                table: "Inventories",
                newName: "IX_Inventories_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventoties_ColorId",
                table: "Inventories",
                newName: "IX_Inventories_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Colors_ColorId",
                table: "Inventories",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Vehicles_VehicleId",
                table: "Inventories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Colors_ColorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Vehicles_VehicleId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventoties");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_VehicleId",
                table: "Inventoties",
                newName: "IX_Inventoties_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_ColorId",
                table: "Inventoties",
                newName: "IX_Inventoties_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventoties",
                table: "Inventoties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoties_Colors_ColorId",
                table: "Inventoties",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoties_Vehicles_VehicleId",
                table: "Inventoties",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
