using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShareServiceModel",
                columns: table => new
                {
                    ShareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
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
