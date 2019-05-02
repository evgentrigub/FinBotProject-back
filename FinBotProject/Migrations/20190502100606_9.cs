using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "TradingBots");

            migrationBuilder.DropColumn(
                name: "Asset",
                table: "Profit");

            migrationBuilder.AddColumn<int>(
                name: "RiskType",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfitId",
                table: "TradingBots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Industry = table.Column<int>(nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_TradingBots_Profit_ProfitId",
                table: "TradingBots",
                column: "ProfitId",
                principalTable: "Profit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradingBots_Profit_ProfitId",
                table: "TradingBots");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_TradingBots_ProfitId",
                table: "TradingBots");

            migrationBuilder.DropColumn(
                name: "RiskType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfitId",
                table: "TradingBots");

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "TradingBots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Asset",
                table: "Profit",
                nullable: true);
        }
    }
}
