using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KWA_Djole.Data.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCarts_ShoppingItems_ItemId",
                table: "CustomerCarts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CustomerCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCarts_ShoppingItems_ItemId",
                table: "CustomerCarts",
                column: "ItemId",
                principalTable: "ShoppingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCarts_ShoppingItems_ItemId",
                table: "CustomerCarts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CustomerCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCarts_ShoppingItems_ItemId",
                table: "CustomerCarts",
                column: "ItemId",
                principalTable: "ShoppingItems",
                principalColumn: "Id");
        }
    }
}
