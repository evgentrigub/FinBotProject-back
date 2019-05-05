using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TradingBots");

            migrationBuilder.AddColumn<double>(
                name: "ESValue",
                table: "TradingBots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Sum",
                table: "TradingBots",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESValue",
                table: "TradingBots");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "TradingBots");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TradingBots",
                nullable: true);
        }
    }
}
