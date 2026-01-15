using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Warranties",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Warranties",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceItemId1",
                table: "Warranties",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 16, 3, 19, 29, 519, DateTimeKind.Local).AddTicks(1635), "4A9dXZz2esXLPggHYRV8YA==.P7DQ8KGtgE53bPzGosm/4nL1ea5OpTg1ulTrDPrc3gA=" });

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_InvoiceItemId1",
                table: "Warranties",
                column: "InvoiceItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Warranties_InvoiceItems_InvoiceItemId1",
                table: "Warranties",
                column: "InvoiceItemId1",
                principalTable: "InvoiceItems",
                principalColumn: "InvoiceItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warranties_InvoiceItems_InvoiceItemId1",
                table: "Warranties");

            migrationBuilder.DropIndex(
                name: "IX_Warranties_InvoiceItemId1",
                table: "Warranties");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId1",
                table: "Warranties");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Warranties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Warranties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 16, 3, 3, 21, 134, DateTimeKind.Local).AddTicks(2354), "X/MW9LxMyGNH3PXCQY4FsQ==.2gKVQx56cW1VhvQ3/yWhfzz+rHvi51VgYUwgovwZCvs=" });
        }
    }
}
