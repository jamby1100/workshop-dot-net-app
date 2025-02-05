using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHintProgressStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HintStatus",
                table: "HintProgresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HintStatus",
                table: "HintProgresses");
        }
    }
}
