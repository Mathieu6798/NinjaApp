using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinjaApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GoldWorth", "Strength" },
                values: new object[] { 100, 15 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "GoldWorth",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "GoldWorth",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Agility", "GoldWorth", "Intelligence", "Strength" },
                values: new object[] { 6, 20, 10, 3 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Agility", "GoldWorth", "Intelligence", "Strength" },
                values: new object[] { 4, 15, 7, 3 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "GoldWorth",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GoldWorth", "Strength" },
                values: new object[] { 300, 10 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "GoldWorth",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "GoldWorth",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Agility", "GoldWorth", "Intelligence", "Strength" },
                values: new object[] { 3, 200, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Agility", "GoldWorth", "Intelligence", "Strength" },
                values: new object[] { 5, 300, 2, 10 });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "GoldWorth",
                value: 200);
        }
    }
}
