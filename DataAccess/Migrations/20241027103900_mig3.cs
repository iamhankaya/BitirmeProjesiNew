using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_orderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_orderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ordersorderId = table.Column<int>(type: "int", nullable: false),
                    productsproductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ordersorderId, x.productsproductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_ordersorderId",
                        column: x => x.ordersorderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_productsproductId",
                        column: x => x.productsproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_productsproductId",
                table: "OrderProduct",
                column: "productsproductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_orderId",
                table: "Products",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_orderId",
                table: "Products",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId");
        }
    }
}
