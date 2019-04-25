using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBots");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TradingBots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TradingBots_UserId",
                table: "TradingBots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradingBots_Users_UserId",
                table: "TradingBots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradingBots_Users_UserId",
                table: "TradingBots");

            migrationBuilder.DropIndex(
                name: "IX_TradingBots_UserId",
                table: "TradingBots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TradingBots");

            migrationBuilder.CreateTable(
                name: "UsersBots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TradingBotId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersBots_TradingBots_TradingBotId",
                        column: x => x.TradingBotId,
                        principalTable: "TradingBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersBots_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersBots_TradingBotId",
                table: "UsersBots",
                column: "TradingBotId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBots_UserId",
                table: "UsersBots",
                column: "UserId");
        }
    }
}
