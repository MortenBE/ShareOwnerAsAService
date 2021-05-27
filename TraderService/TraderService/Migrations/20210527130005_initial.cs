using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraderService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraderModel",
                columns: table => new
                {
                    TraderId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 86, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraderModel", x => x.TraderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraderModel");
        }
    }
}
