using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teacher_Directory.Migrations
{
    /// <inheritdoc />
    public partial class FixSubjectDepartmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_DepartmentId",
                table: "Subject",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_DepartmentId",
                table: "Subject");

            migrationBuilder.CreateTable(
                name: "DepartmentSubject",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubject", x => new { x.DepartmentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_DepartmentSubject_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubject_SubjectId",
                table: "DepartmentSubject",
                column: "SubjectId");
        }
    }
}
