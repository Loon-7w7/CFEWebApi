using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFEDatabase.Migrations
{
    /// <inheritdoc />
    public partial class devices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("6ebf7098-0fde-452a-b0fb-bb93ed3cf907"));

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    voltage = table.Column<int>(type: "int", nullable: false),
                    isHeavy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isSemiInsulated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AmountsMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    materialId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    DevicesId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountsMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmountsMaterial_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AmountsMaterial_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("f46aa503-7b96-452d-9488-c06128b63637"), new DateTime(2023, 6, 9, 10, 2, 10, 262, DateTimeKind.Local).AddTicks(7276), "123456789", 0, new DateTime(2023, 6, 9, 10, 2, 10, 262, DateTimeKind.Local).AddTicks(7285), "Loon" });

            migrationBuilder.CreateIndex(
                name: "IX_AmountsMaterial_DevicesId",
                table: "AmountsMaterial",
                column: "DevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_AmountsMaterial_materialId",
                table: "AmountsMaterial",
                column: "materialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountsMaterial");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("f46aa503-7b96-452d-9488-c06128b63637"));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("6ebf7098-0fde-452a-b0fb-bb93ed3cf907"), new DateTime(2023, 6, 8, 21, 50, 57, 449, DateTimeKind.Local).AddTicks(7534), "123456789", 0, new DateTime(2023, 6, 8, 21, 50, 57, 449, DateTimeKind.Local).AddTicks(7543), "Loon" });
        }
    }
}
