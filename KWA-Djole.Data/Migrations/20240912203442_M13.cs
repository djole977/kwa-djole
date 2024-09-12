using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRatedByCustomer",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRatedByCustomer",
                table: "OrderItems");
        }
    }
}
