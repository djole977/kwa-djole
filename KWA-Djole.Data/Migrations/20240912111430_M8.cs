using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingItemGenreId",
                table: "ShoppingItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingItemGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItemGenres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ShoppingItemGenreId",
                table: "ShoppingItems",
                column: "ShoppingItemGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems",
                column: "ShoppingItemGenreId",
                principalTable: "ShoppingItemGenres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_ShoppingItemGenres_ShoppingItemGenreId",
                table: "ShoppingItems");

            migrationBuilder.DropTable(
                name: "ShoppingItemGenres");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingItems_ShoppingItemGenreId",
                table: "ShoppingItems");

            migrationBuilder.DropColumn(
                name: "ShoppingItemGenreId",
                table: "ShoppingItems");
        }
    }
}
