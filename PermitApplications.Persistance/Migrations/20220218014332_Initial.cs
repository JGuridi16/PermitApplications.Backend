using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermitApplications.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeLastname = table.Column<string>(nullable: true),
                    PermitTypeId = table.Column<int>(nullable: true),
                    PermitDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permit_PermitType_PermitTypeId",
                        column: x => x.PermitTypeId,
                        principalTable: "PermitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_PermitTypeId",
                table: "Permit",
                column: "PermitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropTable(
                name: "PermitType");
        }
    }
}
