using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentschool.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schools_SchoolId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "DersAdi", "SchoolId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LessonId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schools_SchoolId",
                table: "Lessons",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schools_SchoolId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LessonId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schools_SchoolId",
                table: "Lessons",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }
    }
}
