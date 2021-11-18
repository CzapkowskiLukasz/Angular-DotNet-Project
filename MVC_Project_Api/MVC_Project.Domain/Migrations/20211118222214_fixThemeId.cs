using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Project.Domain.Migrations
{
    public partial class fixThemeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeID",
                table: "Theme",
                newName: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Theme",
                newName: "ThemeID");
        }
    }
}
