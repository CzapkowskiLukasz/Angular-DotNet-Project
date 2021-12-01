using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Project.Domain.Migrations
{
    public partial class AddProducersMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producer_Country_CountryId",
                table: "Producer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Producer",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "Producer_Country_FK",
                table: "Producer",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Producer_Country_FK",
                table: "Producer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Producer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Producer_Country_CountryId",
                table: "Producer",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
