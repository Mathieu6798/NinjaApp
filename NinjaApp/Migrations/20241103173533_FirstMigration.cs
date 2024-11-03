using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NinjaApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    GoldWorth = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AmountOfGold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinjaEquipments",
                columns: table => new
                {
                    NinjaId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaEquipments", x => new { x.NinjaId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_NinjaEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinjaEquipments_Ninjas_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Agility", "GoldWorth", "Intelligence", "Name", "Strength", "Type" },
                values: new object[,]
                {
                    { 1, 5, 100, 3, "Diamond Sword", 20, 2 },
                    { 2, 4, 35, 2, "Diamond Helmet", 8, 0 },
                    { 3, 6, 50, 3, "Diamond Chestplate", 12, 1 },
                    { 4, 7, 25, 9, "Diamond Boots", 4, 3 },
                    { 5, 5, 22, 8, "Lord of the Ring", 6, 4 },
                    { 6, 3, 15, 4, "Pearl Necklace", 7, 5 },
                    { 7, 6, 28, 3, "Iron Sword", 16, 2 },
                    { 8, 4, 32, 2, "Iron Helmet", 9, 0 },
                    { 9, 7, 45, 4, "Iron Chestplate", 13, 1 },
                    { 10, 8, 27, 10, "Iron Boots", 5, 3 },
                    { 11, 9, 18, 5, "Speed Ring", 4, 4 },
                    { 12, 4, 12, 3, "Diamond Necklace", 6, 5 },
                    { 13, 6, 14, 2, "Wooden Sword", 14, 2 },
                    { 14, 4, 26, 2, "Wooden Helmet", 6, 0 },
                    { 15, 6, 42, 3, "Wooden Chestplate", 11, 1 },
                    { 16, 8, 24, 7, "Wooden Boots", 3, 3 },
                    { 17, 5, 17, 6, "Strength Ring", 10, 4 },
                    { 18, 10, 11, 2, "Agility Necklace", 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "AmountOfGold", "Name" },
                values: new object[,]
                {
                    { 1, 100, "Shadow" },
                    { 2, 150, "Blade" }
                });

            migrationBuilder.InsertData(
                table: "NinjaEquipments",
                columns: new[] { "EquipmentId", "NinjaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NinjaEquipments_EquipmentId",
                table: "NinjaEquipments",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaEquipments");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}
