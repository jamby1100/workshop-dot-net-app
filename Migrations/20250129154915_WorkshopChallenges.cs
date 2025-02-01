using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class WorkshopChallenges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateTimeToFinish = table.Column<double>(type: "float", nullable: false),
                    ChallengeBriefMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.ChallengeId);
                    table.ForeignKey(
                        name: "FK_Challenge_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_WorkshopId",
                table: "Challenges",
                column: "WorkshopId"
            );

            // migrationBuilder.InsertData(
            //     table: "Workshops",
            //     columns: new[] { "WorkshopId", "Description", "EstimateTimeToFinish", "Name", "Published" },
            //     values: new object[] { 1, "This is a challenge that will teach you all you need to know about serverless.", 120.0, "Serverless Challenge III", true });

            // migrationBuilder.InsertData(
            //     table: "Challenges",
            //     columnTypes: new string[] { "int", "string", "int", "string", "string", "int" },
            //     columns: new[] { "ChallengeId", "Description", "EstimateTimeToFinish", "Name", "ChallengeBriefMarkdown", "WorkshopId" },
            //     values: new object[] { 1, "Hello World", 10.0, "Get Started Guide", "# This is it [some link](https://google.com)", 1 
            // });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Challenges");
        }
    }
}
