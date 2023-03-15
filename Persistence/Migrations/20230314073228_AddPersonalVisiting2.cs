using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddPersonalVisiting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PersonVisitings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonVisitings_StatusId",
                table: "PersonVisitings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonVisitings_Statuses_StatusId",
                table: "PersonVisitings",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonVisitings_Statuses_StatusId",
                table: "PersonVisitings");

            migrationBuilder.DropIndex(
                name: "IX_PersonVisitings_StatusId",
                table: "PersonVisitings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PersonVisitings");
        }
    }
}
