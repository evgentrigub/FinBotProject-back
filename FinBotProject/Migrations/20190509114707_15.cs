using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialInstrument",
                table: "TradingBots");

            migrationBuilder.AddColumn<int>(
                name: "FinancialInstrument",
                table: "Assets",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_TradingBots_TradingBotId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_TradingBotId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "FinancialInstrument",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "TradingBotId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "FinancialInstrument",
                table: "TradingBots",
                nullable: false,
                defaultValue: 0);
        }
    }
}
