using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 13, 47, 688, DateTimeKind.Local).AddTicks(5815), "qwirsBJNPUDrTeUWeyYqkA==.EOadNI9Fui0XnGoh3hI9//BB8nWdg75t08j7MrcYqeQ=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppAdminAccounts",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 9, 9, 456, DateTimeKind.Local).AddTicks(7372), "CkTauNm1BUKfJdqK+Xaqog==.3s0J2aHhZ36AwhjieljMb+sY+ierqCH/aeMAps3G7fI=" });
        }
    }
}
