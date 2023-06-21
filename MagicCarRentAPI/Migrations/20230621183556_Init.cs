using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicCarRentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CarColor = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    TotalRentTime = table.Column<double>(type: "float", nullable: false),
                    TotalMoneyEarn = table.Column<double>(type: "float", nullable: false),
                    IsRentedNow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    TotalPay = table.Column<double>(type: "float", nullable: false),
                    TotalDebt = table.Column<double>(type: "float", nullable: false),
                    TotalDrivingTime = table.Column<double>(type: "float", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientJournals",
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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CarColor", "Cost", "IsRentedNow", "Model", "TotalMoneyEarn", "TotalRentTime", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 0, 2000.0, false, "Mark II", 0.0, 0.0, 1995 },
                    { 2, "Honda", 1, 2200.0, false, "Civic", 0.0, 0.0, 2010 },
                    { 3, "Ford", 2, 5000.0, false, "Mustang", 0.0, 0.0, 2015 },
                    { 4, "Chevrolet", 3, 7000.0, false, "Camaro", 0.0, 0.0, 2018 },
                    { 5, "BMW", 4, 6000.0, false, "M5", 0.0, 0.0, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Experience", "Lastname", "Name", "Score", "TotalBill", "TotalDebt", "TotalDrivingTime", "TotalPay" },
                values: new object[,]
                {
                    { 1, 0.0, "Doe", "John", 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 2, 0.0, "Smith", "Alice", 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 3, 0.0, "Johnson", "Michael", 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 4, 0.0, "Brown", "Emily", 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 5, 0.0, "Wilson", "David", 0.0, 0.0, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountName", "DiscountRate" },
                values: new object[,]
                {
                    { 1, "Скидка 1-й уровень", 0.050000000000000003 },
                    { 2, "Скидка 2-й уровень", 0.10000000000000001 },
                    { 3, "Скидка 3-й уровень", 0.14999999999999999 },
                    { 4, "Скидка 4-й уровень", 0.20000000000000001 },
                    { 5, "Скидка 5-й уровень", 0.25 }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientJournals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
