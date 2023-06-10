using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFEDatabase.Migrations
{
    /// <inheritdoc />
    public partial class llaveforaneaPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("f46aa503-7b96-452d-9488-c06128b63637"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("80d4e6e6-4137-4531-a385-2602f695924f"));

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "AmountsMaterial");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("f46aa503-7b96-452d-9488-c06128b63637"), new DateTime(2023, 6, 9, 10, 2, 10, 262, DateTimeKind.Local).AddTicks(7276), "123456789", 0, new DateTime(2023, 6, 9, 10, 2, 10, 262, DateTimeKind.Local).AddTicks(7285), "Loon" });
        }
    }
}
