using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HintProgresses",
                columns: table => new
                {
                    HintProgressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HintProgresses", x => x.HintProgressId);
                    table.ForeignKey(
                        name: "FK_HintProgresses_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HintProgresses_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Hints",
                columns: table => new
                {
                    HintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hints", x => x.HintId);
                    table.ForeignKey(
                        name: "FK_Hints_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Hints_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PointsLedgerEntries",
                columns: table => new
                {
                    PointsLedgerEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsLedgerEntries", x => x.PointsLedgerEntryId);
                    table.ForeignKey(
                        name: "FK_PointsLedgerEntries_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HintProgresses_ChallengeId",
                table: "HintProgresses",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_HintProgresses_WorkshopId",
                table: "HintProgresses",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Hints_ChallengeId",
                table: "Hints",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hints_WorkshopId",
                table: "Hints",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsLedgerEntries_WorkshopId",
                table: "PointsLedgerEntries",
                column: "WorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HintProgresses");

            migrationBuilder.DropTable(
                name: "Hints");

            migrationBuilder.DropTable(
                name: "PointsLedgerEntries");
        }
    }
}
