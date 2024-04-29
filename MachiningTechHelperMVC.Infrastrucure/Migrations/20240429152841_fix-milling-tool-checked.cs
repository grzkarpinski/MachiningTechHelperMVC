using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class fixmillingtoolchecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MillingToolsCheckedParameters_MillingInserts_MillingInsertId",
                table: "MillingToolsCheckedParameters");

            migrationBuilder.DropIndex(
                name: "IX_MillingToolsCheckedParameters_MillingInsertId",
                table: "MillingToolsCheckedParameters");

            migrationBuilder.DropColumn(
                name: "MillingInsertId",
                table: "MillingToolsCheckedParameters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MillingInsertId",
                table: "MillingToolsCheckedParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MillingToolsCheckedParameters_MillingInsertId",
                table: "MillingToolsCheckedParameters",
                column: "MillingInsertId");

            migrationBuilder.AddForeignKey(
                name: "FK_MillingToolsCheckedParameters_MillingInserts_MillingInsertId",
                table: "MillingToolsCheckedParameters",
                column: "MillingInsertId",
                principalTable: "MillingInserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
