using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveChallengeAndWorkshopAssociationsFromHintProgressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HintProgresses_Challenges_ChallengeId",
                table: "HintProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_HintProgresses_Workshops_WorkshopId",
                table: "HintProgresses");

            migrationBuilder.DropIndex(
                name: "IX_HintProgresses_ChallengeId",
                table: "HintProgresses");

            migrationBuilder.DropIndex(
                name: "IX_HintProgresses_WorkshopId",
                table: "HintProgresses");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "HintProgresses");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "HintProgresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChallengeId",
                table: "HintProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkshopId",
                table: "HintProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HintProgresses_ChallengeId",
                table: "HintProgresses",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_HintProgresses_WorkshopId",
                table: "HintProgresses",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_HintProgresses_Challenges_ChallengeId",
                table: "HintProgresses",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HintProgresses_Workshops_WorkshopId",
                table: "HintProgresses",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
