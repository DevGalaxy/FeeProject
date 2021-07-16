using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class subjectdependancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subjectDepedances",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    DependID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectDepedances", x => new { x.SubjectID, x.DependID });
                    table.ForeignKey(
                        name: "FK_subjectDepedances_Subjects_DependID",
                        column: x => x.DependID,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_subjectDepedances_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subjectDepedances_DependID",
                table: "subjectDepedances",
                column: "DependID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subjectDepedances");
        }
    }
}
