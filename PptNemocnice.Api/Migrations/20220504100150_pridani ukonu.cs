using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class pridaniukonu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ukons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UkonDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JmenoPacient = table.Column<string>(type: "TEXT", nullable: false),
                    PrijmeniPacient = table.Column<string>(type: "TEXT", nullable: false),
                    VybaveniId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ukons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ukons_Vybavenis_VybaveniId",
                        column: x => x.VybaveniId,
                        principalTable: "Vybavenis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ukons_VybaveniId",
                table: "Ukons",
                column: "VybaveniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ukons");
        }
    }
}
