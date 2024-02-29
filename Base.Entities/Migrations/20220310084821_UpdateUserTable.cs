using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 3, 10, 16, 48, 20, 188, DateTimeKind.Local).AddTicks(8439), new DateTime(2022, 3, 10, 16, 48, 20, 188, DateTimeKind.Local).AddTicks(8448), "Role", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "tbl_user");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 7, 21, 23, 26, 568, DateTimeKind.Local).AddTicks(968), new DateTime(2022, 3, 7, 21, 23, 26, 568, DateTimeKind.Local).AddTicks(976) });
        }
    }
}
