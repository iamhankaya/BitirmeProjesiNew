using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_cartscardId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_productsproductId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_ordersorderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_productsproductId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "reviewId",
                table: "Reviews",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "paymentId",
                table: "Payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productsproductId",
                table: "OrderProduct",
                newName: "productsid");

            migrationBuilder.RenameColumn(
                name: "ordersorderId",
                table: "OrderProduct",
                newName: "ordersid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_productsproductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_productsid");

            migrationBuilder.RenameColumn(
                name: "creditCardId",
                table: "CreditCards",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "cardId",
                table: "Carts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productsproductId",
                table: "CartProduct",
                newName: "productsid");

            migrationBuilder.RenameColumn(
                name: "cartscardId",
                table: "CartProduct",
                newName: "cartsid");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_productsproductId",
                table: "CartProduct",
                newName: "IX_CartProduct_productsid");

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updateTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_cartsid",
                table: "CartProduct",
                column: "cartsid",
                principalTable: "Carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_productsid",
                table: "CartProduct",
                column: "productsid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_ordersid",
                table: "OrderProduct",
                column: "ordersid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_productsid",
                table: "OrderProduct",
                column: "productsid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_cartsid",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_productsid",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_ordersid",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_productsid",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "updateTime",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "updateTime",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "reviewId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payments",
                newName: "paymentId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "productsid",
                table: "OrderProduct",
                newName: "productsproductId");

            migrationBuilder.RenameColumn(
                name: "ordersid",
                table: "OrderProduct",
                newName: "ordersorderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_productsid",
                table: "OrderProduct",
                newName: "IX_OrderProduct_productsproductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CreditCards",
                newName: "creditCardId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "cardId");

            migrationBuilder.RenameColumn(
                name: "productsid",
                table: "CartProduct",
                newName: "productsproductId");

            migrationBuilder.RenameColumn(
                name: "cartsid",
                table: "CartProduct",
                newName: "cartscardId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_productsid",
                table: "CartProduct",
                newName: "IX_CartProduct_productsproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_cartscardId",
                table: "CartProduct",
                column: "cartscardId",
                principalTable: "Carts",
                principalColumn: "cardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_productsproductId",
                table: "CartProduct",
                column: "productsproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_ordersorderId",
                table: "OrderProduct",
                column: "ordersorderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_productsproductId",
                table: "OrderProduct",
                column: "productsproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
