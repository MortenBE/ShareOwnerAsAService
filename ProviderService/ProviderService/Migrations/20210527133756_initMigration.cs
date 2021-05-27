using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProviderService.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderModel",
                columns: table => new
                {
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderModel", x => x.ProviderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderModel");
        }
    }
}
