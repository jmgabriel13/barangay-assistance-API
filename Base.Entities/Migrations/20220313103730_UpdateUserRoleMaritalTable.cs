using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class UpdateUserRoleMaritalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "tbl_user",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purok",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TermFrom",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TermTo",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 13, 18, 37, 28, 582, DateTimeKind.Local).AddTicks(8783), new DateTime(2022, 3, 13, 18, 37, 28, 582, DateTimeKind.Local).AddTicks(8793) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "Purok",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "TermFrom",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "TermTo",
                table: "tbl_user");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 10, 19, 51, 46, 752, DateTimeKind.Local).AddTicks(4671), new DateTime(2022, 3, 10, 19, 51, 46, 752, DateTimeKind.Local).AddTicks(4719) });
        }
    }
}
