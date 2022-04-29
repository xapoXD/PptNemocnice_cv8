using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class upravaDBcontext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"),
                columns: new[] { "DateTime", "Nazev" },
                values: new object[] { new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi2" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"),
                columns: new[] { "DateTime", "Nazev" },
                values: new object[] { new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"),
                columns: new[] { "DateTime", "Nazev" },
                values: new object[] { new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"),
                columns: new[] { "DateTime", "Nazev" },
                values: new object[] { new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi" });
        }
    }
}
