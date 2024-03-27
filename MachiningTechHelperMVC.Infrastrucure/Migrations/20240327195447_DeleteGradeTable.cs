using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills");

            migrationBuilder.DropForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_SolidMillingTools_GradeId",
                table: "SolidMillingTools");

            migrationBuilder.DropIndex(
                name: "IX_MillingInserts_GradeId",
                table: "MillingInserts");

            migrationBuilder.DropIndex(
                name: "IX_Drills_GradeId",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "SolidMillingTools");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "MillingInserts");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Drills");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerTeethSolid",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMaximum",
                table: "FeedPerTeethSolid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMinimum",
                table: "FeedPerTeethSolid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeedPerTeethSolid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "FeedPerTeethSolid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerTeeth",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMaximum",
                table: "FeedPerTeeth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMinimum",
                table: "FeedPerTeeth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeedPerTeeth",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "FeedPerTeeth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerRevisions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMaximum",
                table: "FeedPerRevisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuttingSpeedMinimum",
                table: "FeedPerRevisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeedPerRevisions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "FeedPerRevisions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuttingSpeedMaximum",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "CuttingSpeedMinimum",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "CuttingSpeedMaximum",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "CuttingSpeedMinimum",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "CuttingSpeedMaximum",
                table: "FeedPerRevisions");

            migrationBuilder.DropColumn(
                name: "CuttingSpeedMinimum",
                table: "FeedPerRevisions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeedPerRevisions");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "FeedPerRevisions");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "SolidMillingTools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "MillingInserts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerTeethSolid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerTeeth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "FeedPerRevisions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Drills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlluminiumCuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    AlluminiumCuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonAlloyedSteelCuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    NonAlloyedSteelCuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    StainlessSteelCuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    StainlessSteelCuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolidMillingTools_GradeId",
                table: "SolidMillingTools",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_MillingInserts_GradeId",
                table: "MillingInserts",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drills_GradeId",
                table: "Drills",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drills_Grades_GradeId",
                table: "Drills",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MillingInserts_Grades_GradeId",
                table: "MillingInserts",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolidMillingTools_Grades_GradeId",
                table: "SolidMillingTools",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");
        }
    }
}
