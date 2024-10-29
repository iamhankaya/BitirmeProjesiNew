using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartcardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartcardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartcardId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    cartscardId = table.Column<int>(type: "int", nullable: false),
                    productsproductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.cartscardId, x.productsproductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_cartscardId",
                        column: x => x.cartscardId,
                        principalTable: "Carts",
                        principalColumn: "cardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_productsproductId",
                        column: x => x.productsproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_productsproductId",
                table: "CartProduct",
                column: "productsproductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.AddColumn<int>(
                name: "CartcardId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartcardId",
                table: "Products",
                column: "CartcardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartcardId",
                table: "Products",
                column: "CartcardId",
                principalTable: "Carts",
                principalColumn: "cardId");
        }
    }
}
