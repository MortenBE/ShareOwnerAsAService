using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProviderService.Migrations
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StockValue",
                table: "ProviderModel",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "TraderId",
                table: "ProviderModel",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockValue",
                table: "ProviderModel");

            migrationBuilder.DropColumn(
                name: "TraderId",
                table: "ProviderModel");
        }
    }
}
