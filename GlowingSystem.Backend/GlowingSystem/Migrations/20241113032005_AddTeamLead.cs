using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlowingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamLead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                column: "TeamLeadId",
                value: new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                column: "TeamLeadId",
                value: new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                column: "TeamLeadId",
                value: new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
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
        }
    }
}
