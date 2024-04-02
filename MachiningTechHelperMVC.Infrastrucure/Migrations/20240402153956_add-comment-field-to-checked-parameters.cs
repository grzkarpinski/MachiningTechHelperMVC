using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class addcommentfieldtocheckedparameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "SolidMillingToolsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "MillingToolsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "DrillsCheckedParameters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "SolidMillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "MillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "DrillsCheckedParameters");
        }
    }
}
