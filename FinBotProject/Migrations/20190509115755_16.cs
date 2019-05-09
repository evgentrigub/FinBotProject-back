using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_TradingBots_TradingBotId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_TradingBotId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "TradingBotId",
                table: "Assets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TradingBotId",
                table: "Assets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TradingBotId",
                table: "Assets",
                column: "TradingBotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_TradingBots_TradingBotId",
                table: "Assets",
                column: "TradingBotId",
                principalTable: "TradingBots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
