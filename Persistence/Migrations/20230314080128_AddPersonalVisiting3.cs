using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddPersonalVisiting3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "PersonVisitings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "GroupVisitings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupVisitings_StatusId",
                table: "GroupVisitings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupVisitings_Statuses_StatusId",
                table: "GroupVisitings",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupVisitings_Statuses_StatusId",
                table: "GroupVisitings");

            migrationBuilder.DropIndex(
                name: "IX_GroupVisitings_StatusId",
                table: "GroupVisitings");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "PersonVisitings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "GroupVisitings");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
