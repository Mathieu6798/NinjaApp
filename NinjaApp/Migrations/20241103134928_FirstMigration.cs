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
                    { 1, 5, 300, 2, "Diamond Sword", 10, 2 },
                    { 2, 3, 200, 1, "Diamond Helmet", 5, 0 },
                    { 3, 5, 300, 2, "Diamond Chestplate", 10, 1 },
                    { 4, 3, 200, 1, "Diamond Boots", 5, 3 },
                    { 5, 5, 300, 2, "Lord of the Ring", 10, 4 },
                    { 6, 3, 200, 1, "Pearl Necklace", 5, 5 }
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
