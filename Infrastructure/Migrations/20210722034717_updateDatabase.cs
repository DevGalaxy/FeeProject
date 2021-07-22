using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffSubjects_Staff_StaffId",
                table: "StaffSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffSubjects_Users_CreatedById",
                table: "StaffSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_studentID",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_subjectID",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffSubjects",
                table: "StaffSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StaffSubjects_CreatedById",
                table: "StaffSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StaffSubjects_StaffId",
                table: "StaffSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MangerID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "studentID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "state",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "AcadimicYear",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "examDay",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "location",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "sessionType",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "weekDay",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "MangerID",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "subjectID",
                table: "StudentSubjects",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_subjectID",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_SubjectId");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademicNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SubjectDepedances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "SubjectDepedances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubjectDepedances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudentSubjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StaffSubjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeadId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                columns: new[] { "UserId", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffSubjects",
                table: "StaffSubjects",
                columns: new[] { "UserId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectDepedances_CreatedById",
                table: "SubjectDepedances",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffSubjects_Users_UserId",
                table: "StaffSubjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Users_UserId",
                table: "StudentSubjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectDepedances_Users_CreatedById",
                table: "SubjectDepedances",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffSubjects_Users_UserId",
                table: "StaffSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Users_UserId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectDepedances_Users_CreatedById",
                table: "SubjectDepedances");

            migrationBuilder.DropIndex(
                name: "IX_SubjectDepedances_CreatedById",
                table: "SubjectDepedances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffSubjects",
                table: "StaffSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AcademicNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DataOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SubjectDepedances");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SubjectDepedances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectDepedances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StaffSubjects");

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "StudentSubjects",
                newName: "subjectID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_subjectID");

            migrationBuilder.AddColumn<int>(
                name: "studentID",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicYear",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "degree",
                table: "StudentSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StaffSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AcadimicYear",
                table: "StaffSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StaffSubjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "StaffSubjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndAt",
                table: "StaffSubjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "StaffSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StartAt",
                table: "StaffSubjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "examDay",
                table: "StaffSubjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "StaffSubjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sessionType",
                table: "StaffSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "weekDay",
                table: "StaffSubjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangerID",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                columns: new[] { "studentID", "subjectID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffSubjects",
                table: "StaffSubjects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Associations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Empty = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_positions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepratnemtID = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScientificDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    positionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Departments_DepratnemtID",
                        column: x => x.DepratnemtID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_positions_positionID",
                        column: x => x.positionID,
                        principalTable: "positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffSubjects_CreatedById",
                table: "StaffSubjects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSubjects_StaffId",
                table: "StaffSubjects",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById",
                unique: true,
                filter: "[CreatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MangerID",
                table: "Departments",
                column: "MangerID",
                unique: true,
                filter: "[MangerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_CreatedById",
                table: "Associations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_positions_CreatedById",
                table: "positions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CreatedById",
                table: "Staff",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepratnemtID",
                table: "Staff",
                column: "DepratnemtID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_positionID",
                table: "Staff",
                column: "positionID",
                unique: true,
                filter: "[positionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreatedById",
                table: "Students",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments",
                column: "MangerID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffSubjects_Staff_StaffId",
                table: "StaffSubjects",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffSubjects_Users_CreatedById",
                table: "StaffSubjects",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_studentID",
                table: "StudentSubjects",
                column: "studentID",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_subjectID",
                table: "StudentSubjects",
                column: "subjectID",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
