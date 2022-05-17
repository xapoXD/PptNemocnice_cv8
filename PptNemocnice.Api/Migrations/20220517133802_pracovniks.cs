using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class pracovniks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0"));

            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba"));

            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("c58712b5-bbfa-490e-9582-359128cd870e"));

            migrationBuilder.AddColumn<Guid>(
                name: "PracovnikId",
                table: "Ukons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pracovniks",
                columns: table => new
                {
                    PracovnikId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracovniks", x => x.PracovnikId);
                });

            migrationBuilder.InsertData(
                table: "Pracovniks",
                columns: new[] { "PracovnikId", "Name" },
                values: new object[] { new Guid("071c0f36-82c6-4ecc-ac8e-37130ef35226"), "Navara" });

            migrationBuilder.InsertData(
                table: "Pracovniks",
                columns: new[] { "PracovnikId", "Name" },
                values: new object[] { new Guid("547184e4-9a55-4172-9ffb-7ece02cd29c3"), "Reichl" });

            migrationBuilder.InsertData(
                table: "Pracovniks",
                columns: new[] { "PracovnikId", "Name" },
                values: new object[] { new Guid("8ae660c7-7660-436b-9bed-ca76faa2c617"), "Paroubek" });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PracovnikId", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("148bf078-5d39-47ef-a465-889ede7d2062"), "Johnny", "scan", null, "Karasek", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PracovnikId", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("d72872dc-47d4-4f5c-95a3-78c50c936c25"), "Paul", "probmemek", null, "Puta", new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c58712b5-bbfa-490e-9582-359128cd870e") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PracovnikId", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("f136bbaa-faa7-4343-b29e-9887c767b265"), "Dave", "profiscan", null, "Paid", new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0") });

            migrationBuilder.CreateIndex(
                name: "IX_Ukons_PracovnikId",
                table: "Ukons",
                column: "PracovnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukons_Pracovniks_PracovnikId",
                table: "Ukons",
                column: "PracovnikId",
                principalTable: "Pracovniks",
                principalColumn: "PracovnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukons_Pracovniks_PracovnikId",
                table: "Ukons");

            migrationBuilder.DropTable(
                name: "Pracovniks");

            migrationBuilder.DropIndex(
                name: "IX_Ukons_PracovnikId",
                table: "Ukons");

            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("148bf078-5d39-47ef-a465-889ede7d2062"));

            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("d72872dc-47d4-4f5c-95a3-78c50c936c25"));

            migrationBuilder.DeleteData(
                table: "Ukons",
                keyColumn: "Id",
                keyValue: new Guid("f136bbaa-faa7-4343-b29e-9887c767b265"));

            migrationBuilder.DropColumn(
                name: "PracovnikId",
                table: "Ukons");

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0"), "Dave", "profiscan", "Paid", new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba"), "Johnny", "scan", "Karasek", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "JmenoPacient", "Name", "PrijmeniPacient", "UkonDateTime", "VybaveniId" },
                values: new object[] { new Guid("c58712b5-bbfa-490e-9582-359128cd870e"), "Paul", "probmemek", "Puta", new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c58712b5-bbfa-490e-9582-359128cd870e") });
        }
    }
}
