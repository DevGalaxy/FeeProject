using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLab_AspNetUsers_CreatedById",
                table: "DepartmentLab");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLab_Departments_DepartmentID",
                table: "DepartmentLab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLab",
                table: "DepartmentLab");

            migrationBuilder.RenameTable(
                name: "DepartmentLab",
                newName: "DepartmentLabs");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLab_DepartmentID",
                table: "DepartmentLabs",
                newName: "IX_DepartmentLabs_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLab_CreatedById",
                table: "DepartmentLabs",
                newName: "IX_DepartmentLabs_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLabs",
                table: "DepartmentLabs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLabs_AspNetUsers_CreatedById",
                table: "DepartmentLabs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLabs_Departments_DepartmentID",
                table: "DepartmentLabs",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLabs_AspNetUsers_CreatedById",
                table: "DepartmentLabs");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLabs_Departments_DepartmentID",
                table: "DepartmentLabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLabs",
                table: "DepartmentLabs");

            migrationBuilder.RenameTable(
                name: "DepartmentLabs",
                newName: "DepartmentLab");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLabs_DepartmentID",
                table: "DepartmentLab",
                newName: "IX_DepartmentLab_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLabs_CreatedById",
                table: "DepartmentLab",
                newName: "IX_DepartmentLab_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLab",
                table: "DepartmentLab",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLab_AspNetUsers_CreatedById",
                table: "DepartmentLab",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLab_Departments_DepartmentID",
                table: "DepartmentLab",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
