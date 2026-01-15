using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitesProduct2 : Migration
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
                values: new object[] { new DateTime(2026, 1, 15, 0, 9, 9, 456, DateTimeKind.Local).AddTicks(7372), "CkTauNm1BUKfJdqK+Xaqog==.3s0J2aHhZ36AwhjieljMb+sY+ierqCH/aeMAps3G7fI=" });
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
                values: new object[] { new DateTime(2026, 1, 15, 0, 6, 11, 130, DateTimeKind.Local).AddTicks(1486), "WC5yZ1/rQ95Nk71gHBfn5w==.RCmawC5tTOnmd+JOihO/+9H9ch3mwI8TBcZ3mnQutd8=" });
        }
    }
}
