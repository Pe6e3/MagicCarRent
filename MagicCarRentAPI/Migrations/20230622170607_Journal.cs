using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCarRentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Journal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientJournals");

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    BeginRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    RentBill = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journal_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_CarID",
                table: "Journal",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_ClientID",
                table: "Journal",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_DiscountId",
                table: "Journal",
                column: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.CreateTable(
                name: "ClientJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    BeginRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentBill = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientJournals_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientJournals_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientJournals_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientJournals_CarID",
                table: "ClientJournals",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientJournals_ClientID",
                table: "ClientJournals",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientJournals_DiscountId",
                table: "ClientJournals",
                column: "DiscountId");
        }
    }
}
