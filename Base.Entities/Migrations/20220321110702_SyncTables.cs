using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class SyncTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 21, 19, 7, 1, 298, DateTimeKind.Local).AddTicks(2723), new DateTime(2022, 3, 21, 19, 7, 1, 298, DateTimeKind.Local).AddTicks(2732) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 21, 17, 57, 40, 112, DateTimeKind.Local).AddTicks(7321), new DateTime(2022, 3, 21, 17, 57, 40, 112, DateTimeKind.Local).AddTicks(7328) });
        }
    }
}
