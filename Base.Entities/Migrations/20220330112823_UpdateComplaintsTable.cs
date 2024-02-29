using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class UpdateComplaintsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Statement",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Involved",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complainant",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(6640), new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(9825), new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(8705), new DateTime(2023, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(9132) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "tbl_complaints");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tbl_complaints");

            migrationBuilder.AlterColumn<string>(
                name: "Statement",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Involved",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complainant",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 3, 27, 14, 33, 59, 657, DateTimeKind.Local).AddTicks(6581), new DateTime(2022, 3, 27, 14, 33, 59, 658, DateTimeKind.Local).AddTicks(5540), new DateTime(2022, 3, 27, 14, 33, 59, 658, DateTimeKind.Local).AddTicks(2704), new DateTime(2023, 3, 27, 14, 33, 59, 658, DateTimeKind.Local).AddTicks(3891) });
        }
    }
}
