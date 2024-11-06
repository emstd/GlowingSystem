using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlowingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATE", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEntityProjectEntity",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEntityProjectEntity", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeEntityProjectEntity_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEntityProjectEntity_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "ContractorName" },
                values: new object[,]
                {
                    { new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"), "GenialSolutions" },
                    { new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"), "VeryFastSolutions" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerName" },
                values: new object[,]
                {
                    { new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"), "Yanbex" },
                    { new Guid("39156042-6faf-45f3-b0e9-65f0c1b34ecd"), "Goodle" },
                    { new Guid("a3f97ff5-f4e9-48a1-a7eb-d84f0c48c460"), "Ramdler" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "IsManager", "LastName", "Surname" },
                values: new object[,]
                {
                    { new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815"), "andrey@gmail.com", "Андрей", false, "Андреев", "Андреевич" },
                    { new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"), "petr@gmail.com", "Петр", true, "Петров", "Петрович" },
                    { new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3"), "ivan@gmail.com", "Иван", true, "Иванов", "Иванович" },
                    { new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889"), "alex@gmail.com", "Алексей", false, "Алексеев", "Алексеевич" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ContractorId", "CustomerId", "EndDate", "Priority", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"), new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"), new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"), new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "miniature-lamp", new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0"), new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"), new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"), null, 1, "studious-doodle", new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"), new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"), new Guid("a3f97ff5-f4e9-48a1-a7eb-d84f0c48c460"), null, 1, "congenial-octo-memory", new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"), new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"), new Guid("39156042-6faf-45f3-b0e9-65f0c1b34ecd"), new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "congenial-waffle", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815"), new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d") },
                    { new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"), new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d") },
                    { new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"), new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0") },
                    { new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"), new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612") },
                    { new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889"), new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612") },
                    { new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3"), new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095") },
                    { new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889"), new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEntityProjectEntity_ProjectsId",
                table: "EmployeeEntityProjectEntity",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ContractorId",
                table: "Projects",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectName",
                table: "Projects",
                column: "ProjectName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEntityProjectEntity");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
