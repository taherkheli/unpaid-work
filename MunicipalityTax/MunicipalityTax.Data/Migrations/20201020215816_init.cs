using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MunicipalityTax.Data.Migrations
{
  public partial class init : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Municipalities",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Municipalities", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "TaxRules",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            MunicipalityId = table.Column<int>(nullable: false),
            Start = table.Column<DateTime>(nullable: false),
            End = table.Column<DateTime>(nullable: false),
            Type = table.Column<int>(nullable: false),
            Rate = table.Column<double>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_TaxRules", x => x.Id);
            table.ForeignKey(
                      name: "FK_TaxRules_Municipalities_MunicipalityId",
                      column: x => x.MunicipalityId,
                      principalTable: "Municipalities",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_TaxRules_MunicipalityId",
          table: "TaxRules",
          column: "MunicipalityId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "TaxRules");

      migrationBuilder.DropTable(
          name: "Municipalities");
    }
  }
}
