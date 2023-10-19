using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Order_OrderId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CartId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_OrderId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "CartGame",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartGame", x => new { x.CartsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CartGame_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameOrder",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOrder", x => new { x.GamesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_GameOrder_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameOrder_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartGame_GamesId",
                table: "CartGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameOrder_OrdersId",
                table: "GameOrder",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartGame");

            migrationBuilder.DropTable(
                name: "GameOrder");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CartId",
                table: "Games",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OrderId",
                table: "Games",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Order_OrderId",
                table: "Games",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
