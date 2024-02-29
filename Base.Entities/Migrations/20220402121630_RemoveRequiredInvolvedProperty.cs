using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class RemoveRequiredInvolvedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Involved",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "BirthPlace", "DateCreated", "PhotoPath", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(7211), "Tabi tabi", new DateTime(2022, 4, 2, 20, 16, 28, 959, DateTimeKind.Local).AddTicks(952), "", new DateTime(2022, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(9508), new DateTime(2023, 4, 2, 20, 16, 28, 958, DateTimeKind.Local).AddTicks(9915) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Involved",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "BirthPlace", "DateCreated", "PhotoPath", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 6, 25, 666, DateTimeKind.Local).AddTicks(6421), null, new DateTime(2022, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(4481), null, new DateTime(2022, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(3176), new DateTime(2023, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(3752) });
        }
    }
}
