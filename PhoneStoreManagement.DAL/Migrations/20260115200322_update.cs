using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warranties_Customers_CustomerId",
                table: "Warranties");

            migrationBuilder.DropForeignKey(
                name: "FK_Warranties_Products_ProductId",
                table: "Warranties");

            migrationBuilder.DropIndex(
                name: "IX_Warranties_ProductId",
                table: "Warranties");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Warranties");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Warranties");

            migrationBuilder.RenameColumn(
                name: "WarrantyNo",
                table: "Warranties",
                newName: "CustomerPhone");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Warranties",
                newName: "CustomerName");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Warranties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 16, 3, 3, 21, 134, DateTimeKind.Local).AddTicks(2354), "X/MW9LxMyGNH3PXCQY4FsQ==.2gKVQx56cW1VhvQ3/yWhfzz+rHvi51VgYUwgovwZCvs=" });

            migrationBuilder.AddForeignKey(
                name: "FK_Warranties_Customers_CustomerId",
                table: "Warranties",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warranties_Customers_CustomerId",
                table: "Warranties");

            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "Warranties",
                newName: "WarrantyNo");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Warranties",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Warranties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Warranties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Warranties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 19, 32, 219, DateTimeKind.Local).AddTicks(9807), "Kz9pDJqCnQcwfnuOpJT46A==.rhk4l65vXgMMbP2mPELNwwL55ZVPd1XolZagqxZ45Bk=" });

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_ProductId",
                table: "Warranties",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warranties_Customers_CustomerId",
                table: "Warranties",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warranties_Products_ProductId",
                table: "Warranties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
