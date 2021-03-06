using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RequesterService.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequesterModel",
                columns: table => new
                {
                    RequesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Share = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequesterModel", x => x.RequesterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequesterModel");
        }
    }
}
