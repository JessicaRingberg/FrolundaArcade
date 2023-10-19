using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations
{
    public partial class addGameIdToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Games_GameId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Review",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Games_GameId",
                table: "Review",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Games_GameId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Review",
                newName: "ReviewId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Games_GameId",
                table: "Review",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
