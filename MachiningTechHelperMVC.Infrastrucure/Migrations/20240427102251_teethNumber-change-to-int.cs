using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class teethNumberchangetoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeethNumber",
                table: "SolidMillingTools",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "TeethNumber",
                table: "MillingTools",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "TeethNumber",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeethNumber",
                table: "Drills");

            migrationBuilder.AlterColumn<double>(
                name: "TeethNumber",
                table: "SolidMillingTools",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TeethNumber",
                table: "MillingTools",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
