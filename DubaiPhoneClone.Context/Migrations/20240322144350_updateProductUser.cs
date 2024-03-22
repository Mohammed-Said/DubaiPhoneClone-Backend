using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DubaiPhoneClone.Context.Migrations
{
    /// <inheritdoc />
    public partial class updateProductUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Products_WishlistItemsId",
                table: "ProductUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Users_WishlistItemsId1",
                table: "ProductUser");

            migrationBuilder.RenameColumn(
                name: "WishlistItemsId1",
                table: "ProductUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "WishlistItemsId",
                table: "ProductUser",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUser_WishlistItemsId1",
                table: "ProductUser",
                newName: "IX_ProductUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Products_ProductsId",
                table: "ProductUser",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Users_UsersId",
                table: "ProductUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Products_ProductsId",
                table: "ProductUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Users_UsersId",
                table: "ProductUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ProductUser",
                newName: "WishlistItemsId1");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductUser",
                newName: "WishlistItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUser_UsersId",
                table: "ProductUser",
                newName: "IX_ProductUser_WishlistItemsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Products_WishlistItemsId",
                table: "ProductUser",
                column: "WishlistItemsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Users_WishlistItemsId1",
                table: "ProductUser",
                column: "WishlistItemsId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
