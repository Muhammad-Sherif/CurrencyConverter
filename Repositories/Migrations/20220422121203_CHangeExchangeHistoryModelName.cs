using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class CHangeExchangeHistoryModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangesHistory");

            migrationBuilder.CreateTable(
                name: "ExchangeRatesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRatesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRatesHistory_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRatesHistory_CurrencyId",
                table: "ExchangeRatesHistory",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRatesHistory");

            migrationBuilder.CreateTable(
                name: "ExchangesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangesHistory_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangesHistory_CurrencyId",
                table: "ExchangesHistory",
                column: "CurrencyId");
        }
    }
}
