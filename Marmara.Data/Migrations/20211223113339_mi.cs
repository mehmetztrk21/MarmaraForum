using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmara.Data.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 23, 14, 33, 38, 933, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 2, 14, 33, 38, 934, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 12, 23, 14, 33, 38, 934, DateTimeKind.Local).AddTicks(1322));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 11, 12, 16, 59, 897, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 12, 21, 12, 16, 59, 898, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 12, 11, 12, 16, 59, 898, DateTimeKind.Local).AddTicks(3098));
        }
    }
}
