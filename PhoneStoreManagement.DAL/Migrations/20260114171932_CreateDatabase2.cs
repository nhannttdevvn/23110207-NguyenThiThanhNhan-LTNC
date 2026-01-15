using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 19, 32, 219, DateTimeKind.Local).AddTicks(9807), "Kz9pDJqCnQcwfnuOpJT46A==.rhk4l65vXgMMbP2mPELNwwL55ZVPd1XolZagqxZ45Bk=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
