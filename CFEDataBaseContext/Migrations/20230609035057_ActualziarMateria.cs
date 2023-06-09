using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFEDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ActualziarMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("5864651f-e5d2-461e-bf60-3c670d165bfd"));

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Hierarchy",
                table: "Materials");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("6ebf7098-0fde-452a-b0fb-bb93ed3cf907"), new DateTime(2023, 6, 8, 21, 50, 57, 449, DateTimeKind.Local).AddTicks(7534), "123456789", 0, new DateTime(2023, 6, 8, 21, 50, 57, 449, DateTimeKind.Local).AddTicks(7543), "Loon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("6ebf7098-0fde-452a-b0fb-bb93ed3cf907"));

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Materials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Hierarchy",
                table: "Materials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("5864651f-e5d2-461e-bf60-3c670d165bfd"), new DateTime(2023, 5, 28, 9, 26, 52, 219, DateTimeKind.Local).AddTicks(2480), "123456789", 0, new DateTime(2023, 5, 28, 9, 26, 52, 219, DateTimeKind.Local).AddTicks(2494), "Loon" });
        }
    }
}
