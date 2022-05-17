using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class kodvukon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "Ukons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("148bf078-5d39-47ef-a465-889ede7d2062"),
                column: "Kod",
                value: "");

            migrationBuilder.UpdateData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("d72872dc-47d4-4f5c-95a3-78c50c936c25"),
                column: "Kod",
                value: "");

            migrationBuilder.UpdateData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("f136bbaa-faa7-4343-b29e-9887c767b265"),
                column: "Kod",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kod",
                table: "Ukons");
        }
    }
}
