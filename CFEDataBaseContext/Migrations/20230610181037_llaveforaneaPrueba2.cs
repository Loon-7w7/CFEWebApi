using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFEDatabase.Migrations
{
    /// <inheritdoc />
    public partial class llaveforaneaPrueba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmountsMaterial_Devices_DevicesId",
                table: "AmountsMaterial");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("80d4e6e6-4137-4531-a385-2602f695924f"));

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "AmountsMaterial");

            migrationBuilder.AlterColumn<Guid>(
                name: "DevicesId",
                table: "AmountsMaterial",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("3ab322e3-2840-4524-a816-197b7ab9cd75"), new DateTime(2023, 6, 10, 12, 10, 36, 914, DateTimeKind.Local).AddTicks(216), "123456789", 0, new DateTime(2023, 6, 10, 12, 10, 36, 914, DateTimeKind.Local).AddTicks(228), "Loon" });

            migrationBuilder.AddForeignKey(
                name: "FK_AmountsMaterial_Devices_DevicesId",
                table: "AmountsMaterial",
                column: "DevicesId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmountsMaterial_Devices_DevicesId",
                table: "AmountsMaterial");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("3ab322e3-2840-4524-a816-197b7ab9cd75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DevicesId",
                table: "AmountsMaterial",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "AmountsMaterial",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("80d4e6e6-4137-4531-a385-2602f695924f"), new DateTime(2023, 6, 10, 12, 7, 41, 384, DateTimeKind.Local).AddTicks(9186), "123456789", 0, new DateTime(2023, 6, 10, 12, 7, 41, 384, DateTimeKind.Local).AddTicks(9196), "Loon" });

            migrationBuilder.AddForeignKey(
                name: "FK_AmountsMaterial_Devices_DevicesId",
                table: "AmountsMaterial",
                column: "DevicesId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
