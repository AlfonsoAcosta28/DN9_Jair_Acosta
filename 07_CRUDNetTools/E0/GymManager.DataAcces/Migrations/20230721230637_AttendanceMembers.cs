using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.DataAcces.Migrations
{
    public partial class AttendanceMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MembersId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "MembersId",
                table: "Attendances",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_MembersId",
                table: "Attendances",
                newName: "IX_Attendances_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Attendances",
                newName: "MembersId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_MemberId",
                table: "Attendances",
                newName: "IX_Attendances_MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MembersId",
                table: "Attendances",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
