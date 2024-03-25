using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DubaiPhoneClone.Context.Migrations
{
    /// <inheritdoc />
    public partial class ProductCover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Products");
        }
    }
}
