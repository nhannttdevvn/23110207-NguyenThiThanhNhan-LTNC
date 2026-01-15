using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitesProduct1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 6, 11, 130, DateTimeKind.Local).AddTicks(1486), "WC5yZ1/rQ95Nk71gHBfn5w==.RCmawC5tTOnmd+JOihO/+9H9ch3mwI8TBcZ3mnQutd8=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 14, 23, 54, 58, 322, DateTimeKind.Local).AddTicks(974), "LulC7puGd64r2G/T4MVbGw==.TMdEpJd5R+T6pd05nAmib79CLNVOnhFFZ5DU6QjV740=" });
        }
    }
}
