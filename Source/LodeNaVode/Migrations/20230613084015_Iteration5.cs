using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LodeNaVode.Migrations
{
    /// <inheritdoc />
    public partial class Iteration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Lobbies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Lobbies");
        }
    }
}
