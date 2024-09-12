using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_ShoppingItems_ShoppingItemId",
                table: "CustomerReviews");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingItemId",
                table: "CustomerReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "CustomerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReviews_ItemId",
                table: "CustomerReviews",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_OrderItems_ItemId",
                table: "CustomerReviews",
                column: "ItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_ShoppingItems_ShoppingItemId",
                table: "CustomerReviews",
                column: "ShoppingItemId",
                principalTable: "ShoppingItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_OrderItems_ItemId",
                table: "CustomerReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_ShoppingItems_ShoppingItemId",
                table: "CustomerReviews");

            migrationBuilder.DropIndex(
                name: "IX_CustomerReviews_ItemId",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CustomerReviews");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingItemId",
                table: "CustomerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_ShoppingItems_ShoppingItemId",
                table: "CustomerReviews",
                column: "ShoppingItemId",
                principalTable: "ShoppingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
