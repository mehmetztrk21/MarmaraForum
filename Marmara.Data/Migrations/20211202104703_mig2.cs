using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmara.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Okul" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kulüpler" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Context", "Date", "PersonId", "Title" },
                values: new object[] { 1, 1, "Bugün okul yok.", new DateTime(2021, 12, 2, 13, 47, 2, 764, DateTimeKind.Local).AddTicks(781), null, "Okul yok" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Context", "Date", "PersonId", "Title" },
                values: new object[] { 2, 1, "Bugün okul güzel.", new DateTime(2021, 12, 12, 13, 47, 2, 764, DateTimeKind.Local).AddTicks(8582), null, "Okul güzel" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Context", "Date", "PersonId", "Title" },
                values: new object[] { 3, 2, "Tanışma toplantısına davetlisin.", new DateTime(2021, 12, 2, 13, 47, 2, 764, DateTimeKind.Local).AddTicks(8659), null, "Etkileşim kulübü" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
