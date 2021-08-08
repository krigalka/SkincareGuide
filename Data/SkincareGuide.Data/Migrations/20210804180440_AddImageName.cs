using Microsoft.EntityFrameworkCore.Migrations;

namespace SkincareGuide.Data.Migrations
{
    public partial class AddImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Images",
                newName: "NameDB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameDB",
                table: "Images",
                newName: "ImagePath");
        }
    }
}
