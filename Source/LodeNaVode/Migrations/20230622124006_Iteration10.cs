using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LodeNaVode.Migrations
{
    /// <inheritdoc />
    public partial class Iteration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gamemode",
                table: "Lobbies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gamemode",
                table: "Lobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
