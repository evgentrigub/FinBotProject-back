using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _14 : Migration
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

            migrationBuilder.CreateTable(
                name: "BotsAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TradingBotId = table.Column<Guid>(nullable: true),
                    AssetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotsAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotsAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BotsAssets_TradingBots_TradingBotId",
                        column: x => x.TradingBotId,
                        principalTable: "TradingBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotsAssets_AssetId",
                table: "BotsAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_BotsAssets_TradingBotId",
                table: "BotsAssets",
                column: "TradingBotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotsAssets");

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
