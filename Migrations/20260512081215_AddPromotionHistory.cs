using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromotionHistories",
                columns: table => new
                {
                    PromotionHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FromClassId = table.Column<int>(type: "int", nullable: false),
                    ToClassId = table.Column<int>(type: "int", nullable: false),
                    PromotedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionHistories", x => x.PromotionHistoryId);
                    table.ForeignKey(
                        name: "FK_PromotionHistories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionHistories_StudentId",
                table: "PromotionHistories",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionHistories");
        }
    }
}
