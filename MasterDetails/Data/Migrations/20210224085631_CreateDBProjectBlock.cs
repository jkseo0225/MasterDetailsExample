using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDetails.Data.Migrations
{
    public partial class CreateDBProjectBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectEvent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetSmallGen = table.Column<int>(type: "int", nullable: false),
                    TargetSmallSun = table.Column<int>(type: "int", nullable: false),
                    TargetBigGen = table.Column<int>(type: "int", nullable: false),
                    TargetBigSun = table.Column<int>(type: "int", nullable: false),
                    ProductGenSmall = table.Column<int>(type: "int", nullable: false),
                    ProductGenBig = table.Column<int>(type: "int", nullable: false),
                    ProductSunSmall = table.Column<int>(type: "int", nullable: false),
                    ProductSunBig = table.Column<int>(type: "int", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_ProjectId",
                table: "Blocks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
