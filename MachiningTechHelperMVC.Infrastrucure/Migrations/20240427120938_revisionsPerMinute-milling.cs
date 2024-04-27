using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class revisionsPerMinutemilling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevisionsPerSecond",
                table: "SolidMillingToolsCheckedParameters",
                newName: "RevisionsPerMinute");

            migrationBuilder.RenameColumn(
                name: "RevisionsPerSecond",
                table: "MillingToolsCheckedParameters",
                newName: "RevisionsPerMinute");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevisionsPerMinute",
                table: "SolidMillingToolsCheckedParameters",
                newName: "RevisionsPerSecond");

            migrationBuilder.RenameColumn(
                name: "RevisionsPerMinute",
                table: "MillingToolsCheckedParameters",
                newName: "RevisionsPerSecond");
        }
    }
}
