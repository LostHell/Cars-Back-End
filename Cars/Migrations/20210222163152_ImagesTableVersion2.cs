using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Migrations
{
    public partial class ImagesTableVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMG",
                table: "Images",
                newName: "ImageSrc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageSrc",
                table: "Images",
                newName: "IMG");
        }
    }
}
