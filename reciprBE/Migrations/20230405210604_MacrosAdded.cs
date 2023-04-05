using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reciprBE.Migrations
{
    /// <inheritdoc />
    public partial class MacrosAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Macros",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Macros",
                table: "Meals");
        }
    }
}
