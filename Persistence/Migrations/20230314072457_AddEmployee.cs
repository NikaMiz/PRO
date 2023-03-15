using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PersonVisitings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonVisitings_EmployeeId",
                table: "PersonVisitings",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonVisitings_Employees_EmployeeId",
                table: "PersonVisitings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonVisitings_Employees_EmployeeId",
                table: "PersonVisitings");

            migrationBuilder.DropIndex(
                name: "IX_PersonVisitings_EmployeeId",
                table: "PersonVisitings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PersonVisitings");
        }
    }
}
