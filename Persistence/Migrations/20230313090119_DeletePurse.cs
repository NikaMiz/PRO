using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class DeletePurse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonVisitings_Purses_PurseId",
                table: "PersonVisitings");

            migrationBuilder.DropTable(
                name: "Purses");

            migrationBuilder.DropIndex(
                name: "IX_PersonVisitings_PurseId",
                table: "PersonVisitings");

            migrationBuilder.DropColumn(
                name: "PurseId",
                table: "PersonVisitings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurseId",
                table: "PersonVisitings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Purses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonVisitings_PurseId",
                table: "PersonVisitings",
                column: "PurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purses_EmployeeId",
                table: "Purses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purses_Id",
                table: "Purses",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonVisitings_Purses_PurseId",
                table: "PersonVisitings",
                column: "PurseId",
                principalTable: "Purses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
