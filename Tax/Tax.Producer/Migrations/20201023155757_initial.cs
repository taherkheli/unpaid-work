using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tax.Producer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kommune",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommune", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    KommuneId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRule_Kommune_KommuneId",
                        column: x => x.KommuneId,
                        principalTable: "Kommune",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kommune",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b5fd3ac8-e9c1-42f3-b3b2-451955d157b7"), "Copenhagen" });

            migrationBuilder.InsertData(
                table: "Kommune",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5ae87a5c-e9e1-4a6f-9941-17e072641704"), "Sønderborg" });

            migrationBuilder.InsertData(
                table: "Kommune",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0870ef4e-5d89-4cb4-95b8-a420463744ba"), "Vejle" });

            migrationBuilder.InsertData(
                table: "TaxRule",
                columns: new[] { "Id", "End", "KommuneId", "Rate", "Start", "Type" },
                values: new object[,]
                {
                    { new Guid("6ea16e6c-92fc-405e-8a31-8f59ab80fd61"), new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5fd3ac8-e9c1-42f3-b3b2-451955d157b7"), 0.20000000000000001, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { new Guid("e0967c75-dd92-482f-b5ec-f7f83f2fa998"), new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5fd3ac8-e9c1-42f3-b3b2-451955d157b7"), 0.40000000000000002, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("f9a8f089-a077-4169-a377-35d0ca259eff"), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5fd3ac8-e9c1-42f3-b3b2-451955d157b7"), 0.10000000000000001, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("be07f1e2-64d5-4ba6-9687-6be45abe82d5"), new DateTime(2016, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5fd3ac8-e9c1-42f3-b3b2-451955d157b7"), 0.10000000000000001, new DateTime(2016, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxRule_KommuneId",
                table: "TaxRule",
                column: "KommuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRule");

            migrationBuilder.DropTable(
                name: "Kommune");
        }
    }
}
