using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFEDatabase.Migrations
{
    /// <inheritdoc />
    public partial class materialModific : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("4fa56588-ac25-4f93-a911-efe88a252dc4"));

            migrationBuilder.RenameColumn(
                name: "store",
                table: "Materials",
                newName: "Hierarchy");

            migrationBuilder.RenameColumn(
                name: "Lot",
                table: "Materials",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "Folio",
                table: "Materials",
                newName: "Code");

            migrationBuilder.AddColumn<double>(
                name: "unirPrice",
                table: "Materials",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("5864651f-e5d2-461e-bf60-3c670d165bfd"), new DateTime(2023, 5, 28, 9, 26, 52, 219, DateTimeKind.Local).AddTicks(2480), "123456789", 0, new DateTime(2023, 5, 28, 9, 26, 52, 219, DateTimeKind.Local).AddTicks(2494), "Loon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("5864651f-e5d2-461e-bf60-3c670d165bfd"));

            migrationBuilder.DropColumn(
                name: "unirPrice",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Hierarchy",
                table: "Materials",
                newName: "store");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Materials",
                newName: "Folio");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Materials",
                newName: "Lot");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreateDate", "Password", "Role", "UpdateDate", "Username" },
                values: new object[] { new Guid("4fa56588-ac25-4f93-a911-efe88a252dc4"), new DateTime(2023, 5, 26, 7, 5, 13, 567, DateTimeKind.Local).AddTicks(3219), "123456789", 0, new DateTime(2023, 5, 26, 7, 5, 13, 567, DateTimeKind.Local).AddTicks(3228), "Loon" });
        }
    }
}
