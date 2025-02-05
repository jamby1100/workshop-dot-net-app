using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromHint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
