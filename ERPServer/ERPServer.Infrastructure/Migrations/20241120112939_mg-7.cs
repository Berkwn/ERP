using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_recipeDetails_ProductId",
                table: "recipeDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipeDetails_Products_ProductId",
                table: "recipeDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipeDetails_Products_ProductId",
                table: "recipeDetails");

            migrationBuilder.DropIndex(
                name: "IX_recipeDetails_ProductId",
                table: "recipeDetails");
        }
    }
}
