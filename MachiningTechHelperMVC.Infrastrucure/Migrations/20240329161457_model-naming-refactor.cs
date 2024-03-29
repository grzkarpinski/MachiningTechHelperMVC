using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class modelnamingrefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedPerRevisions");

            migrationBuilder.DropTable(
                name: "FeedPerTeeth");

            migrationBuilder.DropTable(
                name: "FeedPerTeethSolid");

            migrationBuilder.CreateTable(
                name: "DrillParametersRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedPerRevisionMinimum = table.Column<double>(type: "float", nullable: false),
                    FeedPerRevisionMaximum = table.Column<double>(type: "float", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillParametersRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillParametersRanges_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MillingInsertParametersRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MillingInsertId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    FeedPerToothMinimum = table.Column<double>(type: "float", nullable: false),
                    FeedPerToothMaximum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillingInsertParametersRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MillingInsertParametersRange_MillingInserts_MillingInsertId",
                        column: x => x.MillingInsertId,
                        principalTable: "MillingInserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolidMillingToolParametersRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolidMillingToolId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    FeedPerToothMinimum = table.Column<double>(type: "float", nullable: false),
                    FeedPerToothMaximum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolidMillingToolParametersRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolidMillingToolParametersRanges_SolidMillingTools_SolidMillingToolId",
                        column: x => x.SolidMillingToolId,
                        principalTable: "SolidMillingTools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillParametersRanges_DrillId",
                table: "DrillParametersRanges",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_MillingInsertParametersRange_MillingInsertId",
                table: "MillingInsertParametersRange",
                column: "MillingInsertId");

            migrationBuilder.CreateIndex(
                name: "IX_SolidMillingToolParametersRanges_SolidMillingToolId",
                table: "SolidMillingToolParametersRanges",
                column: "SolidMillingToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillParametersRanges");

            migrationBuilder.DropTable(
                name: "MillingInsertParametersRange");

            migrationBuilder.DropTable(
                name: "SolidMillingToolParametersRanges");

            migrationBuilder.CreateTable(
                name: "FeedPerRevisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedPerRevisionMaximum = table.Column<double>(type: "float", nullable: false),
                    FeedPerRevisionMinimum = table.Column<double>(type: "float", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedPerRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedPerRevisions_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedPerTeeth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MillingInsertId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedPerToothMaximum = table.Column<double>(type: "float", nullable: false),
                    FeedPerToothMinimum = table.Column<double>(type: "float", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedPerTeeth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedPerTeeth_MillingInserts_MillingInsertId",
                        column: x => x.MillingInsertId,
                        principalTable: "MillingInserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedPerTeethSolid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolidMillingToolId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingSpeedMaximum = table.Column<int>(type: "int", nullable: false),
                    CuttingSpeedMinimum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedPerToothMaximum = table.Column<double>(type: "float", nullable: false),
                    FeedPerToothMinimum = table.Column<double>(type: "float", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedPerTeethSolid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedPerTeethSolid_SolidMillingTools_SolidMillingToolId",
                        column: x => x.SolidMillingToolId,
                        principalTable: "SolidMillingTools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedPerRevisions_DrillId",
                table: "FeedPerRevisions",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedPerTeeth_MillingInsertId",
                table: "FeedPerTeeth",
                column: "MillingInsertId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedPerTeethSolid_SolidMillingToolId",
                table: "FeedPerTeethSolid",
                column: "SolidMillingToolId");
        }
    }
}
