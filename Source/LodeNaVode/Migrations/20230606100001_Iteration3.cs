using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LodeNaVode.Migrations
{
    /// <inheritdoc />
    public partial class Iteration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "LobbyId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "LobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "LobbyId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "LobbyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
