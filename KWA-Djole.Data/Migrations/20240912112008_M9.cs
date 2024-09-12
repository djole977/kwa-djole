using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingItemGenreId",
                table: "ShoppingItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems",
                column: "ShoppingItemGenreId",
                principalTable: "ShoppingItemGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingItemGenreId",
                table: "ShoppingItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems",
                column: "ShoppingItemGenreId",
                principalTable: "ShoppingItemGenres",
                principalColumn: "Id");
        }
    }
}
