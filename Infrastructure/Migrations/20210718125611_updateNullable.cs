using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Departments_DepratnemtID",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_positions_positionID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_positionID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MangerID",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "positionID",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepratnemtID",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MangerID",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_positionID",
                table: "Staff",
                column: "positionID",
                unique: true,
                filter: "[positionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MangerID",
                table: "Departments",
                column: "MangerID",
                unique: true,
                filter: "[MangerID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments",
                column: "MangerID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Departments_DepratnemtID",
                table: "Staff",
                column: "DepratnemtID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_positions_positionID",
                table: "Staff",
                column: "positionID",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Departments_DepratnemtID",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_positions_positionID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_positionID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MangerID",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "positionID",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepratnemtID",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MangerID",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_positionID",
                table: "Staff",
                column: "positionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MangerID",
                table: "Departments",
                column: "MangerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Staff_MangerID",
                table: "Departments",
                column: "MangerID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Departments_DepratnemtID",
                table: "Staff",
                column: "DepratnemtID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_positions_positionID",
                table: "Staff",
                column: "positionID",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
