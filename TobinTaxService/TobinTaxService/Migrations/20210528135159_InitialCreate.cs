using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TobinTaxService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TobinTaxModel",
                columns: table => new
                {
                    TaxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TraderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BoughtStock = table.Column<string>(type: "TEXT", nullable: true),
                    PayedTax = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TobinTaxModel", x => x.TaxId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TobinTaxModel");
        }
    }
}
