using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 16, 26, 429, DateTimeKind.Local).AddTicks(7920), "1ZN2k/MGe0XeenIEBjsATg==.rHwr6eGx3n+v/wfcZZrO9kHai9ij3JqDNdwB3ICrTcE=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 13, 47, 688, DateTimeKind.Local).AddTicks(5815), "qwirsBJNPUDrTeUWeyYqkA==.EOadNI9Fui0XnGoh3hI9//BB8nWdg75t08j7MrcYqeQ=" });
        }
    }
}
