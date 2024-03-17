using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class MakeGradeIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills");

            migrationBuilder.DropForeignKey(
                name: "FK_Drills_Producers_ProducerId",
                table: "Drills");

            migrationBuilder.DropForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts");

            migrationBuilder.DropForeignKey(
                name: "FK_MillingTools_Producers_ProducerId",
                table: "MillingTools");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidMillingTools_Producers_ProducerId",
                table: "SolidMillingTools");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "SolidMillingTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "SolidMillingTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "MillingTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "MillingInserts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Drills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "Drills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drills_Producers_ProducerId",
                table: "Drills",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MillingTools_Producers_ProducerId",
                table: "MillingTools",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolidMillingTools_Producers_ProducerId",
                table: "SolidMillingTools",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills");

            migrationBuilder.DropForeignKey(
                name: "FK_Drills_Producers_ProducerId",
                table: "Drills");

            migrationBuilder.DropForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts");

            migrationBuilder.DropForeignKey(
                name: "FK_MillingTools_Producers_ProducerId",
                table: "MillingTools");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidMillingTools_Producers_ProducerId",
                table: "SolidMillingTools");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "SolidMillingTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "SolidMillingTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "MillingTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "MillingInserts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drills_Producers_ProducerId",
                table: "Drills",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MillingTools_Producers_ProducerId",
                table: "MillingTools",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolidMillingTools_Producers_ProducerId",
                table: "SolidMillingTools",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
