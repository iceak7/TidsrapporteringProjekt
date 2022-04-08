using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TidsrapporteringProjekt.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    EmployedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => x.ProjectEmployeeId);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "EmployedDate", "FirstName", "Gender", "JobTitle", "LastName" },
                values: new object[,]
                {
                    { 1, 22, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isak", "Male", "Programmer", "Jensen" },
                    { 2, 30, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anas", "Male", "Programming Teacher", "Qlok" },
                    { 3, 45, new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reidar", "Male", "Teacher", "Qlok" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "IsActive", "ProjectDescription", "ProjectName" },
                values: new object[,]
                {
                    { 1, false, "Creating a bank-console-application", "Bank Project" },
                    { 2, true, "Creating a time-reporting-application", "Time Reporting Project" },
                    { 3, true, "Teach the students programming", "Teach programming" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "ProjectEmployeeId", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "Comment", "EmployeeId", "EndTime", "ProjectId", "StartTime" },
                values: new object[,]
                {
                    { 3, "I studied", 1, new DateTime(2022, 1, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Worked on the bank project", 1, new DateTime(2021, 12, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Worked on the bank project", 1, new DateTime(2021, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Worked on the time-report project", 1, new DateTime(2022, 4, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 4, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Worked on the time-report project", 1, new DateTime(2022, 4, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 4, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Teached about API", 2, new DateTime(2022, 4, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 4, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Teached about SQL", 2, new DateTime(2022, 1, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Teached about microservices", 3, new DateTime(2022, 3, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectId",
                table: "ProjectEmployees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
