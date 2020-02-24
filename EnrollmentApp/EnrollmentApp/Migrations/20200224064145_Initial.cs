using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programs",
                columns: table => new
                {
                    ProgramName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ProgramName", x => x.ProgramName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    DateOfEnrollement = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(maxLength: 1, nullable: false),
                    ProgramNames = table.Column<int>(nullable: false),
                    courseCode = table.Column<string>(nullable: true),
                    ProgramsProgramName = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_StudentId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_programs_ProgramNames",
                        column: x => x.ProgramNames,
                        principalTable: "programs",
                        principalColumn: "ProgramName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_programs_ProgramsProgramName",
                        column: x => x.ProgramsProgramName,
                        principalTable: "programs",
                        principalColumn: "ProgramName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FeeAmount = table.Column<float>(nullable: false),
                    CreditHour = table.Column<int>(nullable: false),
                    ProgramName = table.Column<int>(nullable: false),
                    semisterName = table.Column<int>(nullable: false),
                    Semisterbatch = table.Column<int>(nullable: false),
                    ProgramsProgramName = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_CourseCode", x => x.Code);
                    table.ForeignKey(
                        name: "FK_courses_programs_ProgramName",
                        column: x => x.ProgramName,
                        principalTable: "programs",
                        principalColumn: "ProgramName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_programs_ProgramsProgramName",
                        column: x => x.ProgramsProgramName,
                        principalTable: "programs",
                        principalColumn: "ProgramName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_ProgramName",
                table: "courses",
                column: "ProgramName");

            migrationBuilder.CreateIndex(
                name: "IX_courses_ProgramsProgramName",
                table: "courses",
                column: "ProgramsProgramName");

            migrationBuilder.CreateIndex(
                name: "IX_courses_StudentId",
                table: "courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramNames",
                table: "Students",
                column: "ProgramNames");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramsProgramName",
                table: "Students",
                column: "ProgramsProgramName");

            migrationBuilder.CreateIndex(
                name: "IX_Students_courseCode",
                table: "Students",
                column: "courseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_courses_courseCode",
                table: "Students",
                column: "courseCode",
                principalTable: "courses",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_programs_ProgramName",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_programs_ProgramsProgramName",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_programs_ProgramNames",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_programs_ProgramsProgramName",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_Students_StudentId",
                table: "courses");

            migrationBuilder.DropTable(
                name: "programs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
