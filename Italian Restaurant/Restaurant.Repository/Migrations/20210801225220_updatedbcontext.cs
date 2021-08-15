using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Repository.Migrations
{
    public partial class updatedbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodInShoppingCarts",
                table: "FoodInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodInOrders",
                table: "FoodInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodInShoppingCarts",
                table: "FoodInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodInOrders",
                table: "FoodInOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInShoppingCarts_FoodId",
                table: "FoodInShoppingCarts",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInOrders_FoodId",
                table: "FoodInOrders",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodInShoppingCarts",
                table: "FoodInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_FoodInShoppingCarts_FoodId",
                table: "FoodInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodInOrders",
                table: "FoodInOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodInOrders_FoodId",
                table: "FoodInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodInShoppingCarts",
                table: "FoodInShoppingCarts",
                columns: new[] { "FoodId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodInOrders",
                table: "FoodInOrders",
                columns: new[] { "FoodId", "OrderId" });
        }
    }
}
