using Microsoft.EntityFrameworkCore.Migrations;

namespace SkincareGuide.Data.Migrations
{
    public partial class ChangeModelImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ingredients_IngredientId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IngredientId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Ingredients",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ImageId",
                table: "Ingredients",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Images_ImageId",
                table: "Ingredients",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Images_ImageId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_ImageId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IngredientId",
                table: "Images",
                column: "IngredientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ingredients_IngredientId",
                table: "Images",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
