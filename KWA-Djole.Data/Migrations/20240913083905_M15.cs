using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_OrderItems_ItemId",
                table: "CustomerReviews");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomerReviews",
                newName: "OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerReviews_ItemId",
                table: "CustomerReviews",
                newName: "IX_CustomerReviews_OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_OrderItems_OrderItemId",
                table: "CustomerReviews",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_OrderItems_OrderItemId",
                table: "CustomerReviews");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "CustomerReviews",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerReviews_OrderItemId",
                table: "CustomerReviews",
                newName: "IX_CustomerReviews_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_OrderItems_ItemId",
                table: "CustomerReviews",
                column: "ItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
