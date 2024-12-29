using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrLeaveManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Rahul Pal", new DateTime(2024, 12, 29, 15, 32, 34, 426, DateTimeKind.Local).AddTicks(4582), 10, "Rahul Pal", new DateTime(2024, 12, 29, 15, 32, 34, 432, DateTimeKind.Local).AddTicks(2034), "Vacation" },
                    { 2, "Devi Pal", new DateTime(2024, 12, 29, 15, 32, 34, 432, DateTimeKind.Local).AddTicks(2647), 12, "Devi Pal", new DateTime(2024, 12, 29, 15, 32, 34, 432, DateTimeKind.Local).AddTicks(2654), "Sick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
