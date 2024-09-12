using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)asd
        {
            migrationBuilder.CreateTable(
                name: "CustomerCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCarts_ShoppingItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ShoppingItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCarts_ItemId",
                table: "CustomerCarts",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCarts");
        }
    }
}
