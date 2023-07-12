using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorello_project.Migrations
{
    public partial class ProductAndProductPhotoAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "productPhotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "productPhotos");
        }
    }
}
