using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProviderService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderModel",
                columns: table => new
                {
                    ProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Stock = table.Column<string>(type: "TEXT", nullable: true),
                    StockId = table.Column<Guid>(type: "TEXT", nullable: false)
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
