using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class AddPurposeTypeComplaintsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurposeType",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(5481), new DateTime(2022, 4, 2, 20, 38, 57, 609, DateTimeKind.Local).AddTicks(301), new DateTime(2022, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(8494), new DateTime(2023, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(8954) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurposeType",
                table: "tbl_complaints");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(7211), new DateTime(2022, 4, 2, 20, 16, 28, 959, DateTimeKind.Local).AddTicks(952), new DateTime(2022, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(9508), new DateTime(2023, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(9915) });
        }
    }
}
