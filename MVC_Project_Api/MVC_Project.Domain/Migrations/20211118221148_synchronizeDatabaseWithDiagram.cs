using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Project.Domain.Migrations
{
    public partial class synchronizeDatabaseWithDiagram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CartProduct_Cart_FK",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Producer_ProducerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Cart_TemporaryCartId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TemporaryCartId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentStatus",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "PredictedDeliveryDuration",
                table: "DeliveryType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Cart",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TemporaryCartId",
                table: "User",
                column: "TemporaryCartId",
                unique: true,
                filter: "[TemporaryCartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ExpertId",
                table: "Product",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VoucherId",
                table: "Order",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "Address_User_FK",
                table: "Address",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "CartProduct_Cart_FK",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Order_Voucher_FK",
                table: "Order",
                column: "VoucherId",
                principalTable: "Voucher",
                principalColumn: "VoucherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Product_Expert_FK",
                table: "Product",
                column: "ExpertId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Product_Producer_FK",
                table: "Product",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "User_Cart_FK",
                table: "User",
                column: "TemporaryCartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Address_User_FK",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "CartProduct_Cart_FK",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "Order_Voucher_FK",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "Product_Expert_FK",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "Product_Producer_FK",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "User_Cart_FK",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TemporaryCartId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Product_ExpertId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_VoucherId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PredictedDeliveryDuration",
                table: "DeliveryType");

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Product",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentStatus",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Cart",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TemporaryCartId",
                table: "User",
                column: "TemporaryCartId");

            migrationBuilder.AddForeignKey(
                name: "CartProduct_Cart_FK",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Producer_ProducerId",
                table: "Product",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Cart_TemporaryCartId",
                table: "User",
                column: "TemporaryCartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
