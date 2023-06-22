using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCarRentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Cars",
                newName: "CostHour");

            migrationBuilder.AddColumn<double>(
                name: "CostDay",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsInService",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CostDay", "CostHour", "IsInService" },
                values: new object[] { 2000.0, 350.0, false });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CostDay", "CostHour", "IsInService" },
                values: new object[] { 2200.0, 400.0, false });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CostDay", "CostHour", "IsInService" },
                values: new object[] { 5000.0, 800.0, false });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CostDay", "CostHour", "IsInService" },
                values: new object[] { 7000.0, 1000.0, false });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CostDay", "CostHour", "IsInService" },
                values: new object[] { 6000.0, 900.0, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDay",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsInService",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CostHour",
                table: "Cars",
                newName: "Cost");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cost",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cost",
                value: 2200.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Cost",
                value: 5000.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Cost",
                value: 7000.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Cost",
                value: 6000.0);
        }
    }
}
