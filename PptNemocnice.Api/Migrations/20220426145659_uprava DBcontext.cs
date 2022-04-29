using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class upravaDBcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0"), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "IDK", 69 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba"), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "RNTGN", 150000 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("c58712b5-bbfa-490e-9582-359128cd870e"), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CT", 200000 });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Nazev", "VybaveniId" },
                values: new object[] { new Guid("682b9a37-b704-4c1d-903d-6136863e08f8"), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi", new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Nazev", "VybaveniId" },
                values: new object[] { new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi", new Guid("c58712b5-bbfa-490e-9582-359128cd870e") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Nazev", "VybaveniId" },
                values: new object[] { new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "idk dalsi", new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("682b9a37-b704-4c1d-903d-6136863e08f8"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("c58712b5-bbfa-490e-9582-359128cd870e"));
        }
    }
}
