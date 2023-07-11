using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Example.EntityFramework.Migrations
{
    public partial class Incentives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventoties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventoties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventoties_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventoties_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleIncentive",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    IncentiveId = table.Column<int>(type: "int", nullable: false),
                    ValidTill = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleIncentive", x => new { x.IncentiveId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleIncentive_Incentives_IncentiveId",
                        column: x => x.IncentiveId,
                        principalTable: "Incentives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleIncentive_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoties_ColorId",
                table: "Inventoties",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoties_VehicleId",
                table: "Inventoties",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleIncentive_VehicleId",
                table: "VehicleIncentive",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventoties");

            migrationBuilder.DropTable(
                name: "VehicleIncentive");
        }
    }
}
