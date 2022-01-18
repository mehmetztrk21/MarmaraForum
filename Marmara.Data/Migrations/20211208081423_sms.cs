using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmara.Data.Migrations
{
    public partial class sms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "PersonId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 8, 11, 14, 22, 668, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 12, 18, 11, 14, 22, 668, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 12, 8, 11, 14, 22, 668, DateTimeKind.Local).AddTicks(9110));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 8, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 12, 18, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 12, 8, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(9704));
        }
    }
}
