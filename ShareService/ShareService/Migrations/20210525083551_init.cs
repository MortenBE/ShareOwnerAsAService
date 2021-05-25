using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShareServiceModel",
                columns: table => new
                {
                    ShareId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Stock = table.Column<string>(type: "TEXT", nullable: true),
                    TraderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareServiceModel", x => x.ShareId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShareServiceModel");
        }
    }
}
