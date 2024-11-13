using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlowingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsManagerProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeesIds",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamLeadId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                column: "TeamLeadId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0"),
                column: "TeamLeadId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                column: "TeamLeadId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                column: "TeamLeadId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamLeadId",
                table: "Projects",
                column: "TeamLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_TeamLeadId",
                table: "Projects",
                column: "TeamLeadId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_TeamLeadId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamLeadId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamLeadId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "EmployeesIds",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815"),
                column: "IsManager",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"),
                column: "IsManager",
                value: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3"),
                column: "IsManager",
                value: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889"),
                column: "IsManager",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                column: "EmployeesIds",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0"),
                column: "EmployeesIds",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                column: "EmployeesIds",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                column: "EmployeesIds",
                value: null);
        }
    }
}
