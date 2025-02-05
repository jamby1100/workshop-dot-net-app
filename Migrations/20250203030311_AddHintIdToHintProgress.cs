using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHintIdToHintProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HintId",
                table: "HintProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HintProgresses_HintId",
                table: "HintProgresses",
                column: "HintId");

            migrationBuilder.AddForeignKey(
                name: "FK_HintProgresses_Hints_HintId",
                table: "HintProgresses",
                column: "HintId",
                principalTable: "Hints",
                principalColumn: "HintId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HintProgresses_Hints_HintId",
                table: "HintProgresses");

            migrationBuilder.DropIndex(
                name: "IX_HintProgresses_HintId",
                table: "HintProgresses");

            migrationBuilder.DropColumn(
                name: "HintId",
                table: "HintProgresses");
        }
    }
}
