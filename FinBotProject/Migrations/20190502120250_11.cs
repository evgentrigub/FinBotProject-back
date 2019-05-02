using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradingBots_Profit_ProfitId",
                table: "TradingBots");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Profit");

            migrationBuilder.DropIndex(
                name: "IX_TradingBots_ProfitId",
                table: "TradingBots");

            migrationBuilder.DropColumn(
                name: "ProfitId",
                table: "TradingBots");

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "TradingBots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Industry = table.Column<int>(nullable: false),
                    TradingBotId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_TradingBots_TradingBotId",
                        column: x => x.TradingBotId,
                        principalTable: "TradingBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TradingBotId",
                table: "Assets",
                column: "TradingBotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "TradingBots");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfitId",
                table: "TradingBots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    StrategyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profit_Strategy_StrategyId",
                        column: x => x.StrategyId,
                        principalTable: "Strategy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Industry = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProfitId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Profit_ProfitId",
                        column: x => x.ProfitId,
                        principalTable: "Profit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradingBots_ProfitId",
                table: "TradingBots",
                column: "ProfitId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ProfitId",
                table: "Asset",
                column: "ProfitId");

            migrationBuilder.CreateIndex(
                name: "IX_Profit_StrategyId",
                table: "Profit",
                column: "StrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradingBots_Profit_ProfitId",
                table: "TradingBots",
                column: "ProfitId",
                principalTable: "Profit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
