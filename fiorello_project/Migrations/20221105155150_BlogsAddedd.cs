using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorello_project.Migrations
{
    public partial class BlogsAddedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Blogs",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Blogs",
                newName: "DateTime");
        }
    }
}
