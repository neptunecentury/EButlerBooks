using Microsoft.EntityFrameworkCore.Migrations;

namespace EButlerBooks.Migrations
{
    public partial class bookFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");
        }
    }
}
