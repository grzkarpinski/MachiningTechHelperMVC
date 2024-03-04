using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Producers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "RevisionsPerSecond",
                table: "DrillsCheckedParameters",
                newName: "RevisionsPerMinute");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SolidMillingToolsCheckedParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SolidMillingToolsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SolidMillingTools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SolidMillingTools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SolidMillingTools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsToolActive",
                table: "SolidMillingTools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ToolType",
                table: "SolidMillingTools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Producers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MillingToolsCheckedParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MillingToolsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MillingTools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MillingTools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MillingTools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsToolActive",
                table: "MillingTools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ToolType",
                table: "MillingTools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MillingInserts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MillingInserts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FeedPerTeethSolid",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FeedPerTeethSolid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FeedPerTeeth",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FeedPerTeeth",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FeedPerRevisions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FeedPerRevisions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DrillsCheckedParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DrillsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Drills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsToolActive",
                table: "Drills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ToolType",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SolidMillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SolidMillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SolidMillingTools");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SolidMillingTools");

            migrationBuilder.DropColumn(
                name: "IsToolActive",
                table: "SolidMillingTools");

            migrationBuilder.DropColumn(
                name: "ToolType",
                table: "SolidMillingTools");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MillingTools");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MillingTools");

            migrationBuilder.DropColumn(
                name: "IsToolActive",
                table: "MillingTools");

            migrationBuilder.DropColumn(
                name: "ToolType",
                table: "MillingTools");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MillingInserts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MillingInserts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FeedPerTeethSolid");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FeedPerTeeth");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FeedPerRevisions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FeedPerRevisions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DrillsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DrillsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "IsToolActive",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "ToolType",
                table: "Drills");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Producers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RevisionsPerMinute",
                table: "DrillsCheckedParameters",
                newName: "RevisionsPerSecond");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SolidMillingTools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MillingTools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
