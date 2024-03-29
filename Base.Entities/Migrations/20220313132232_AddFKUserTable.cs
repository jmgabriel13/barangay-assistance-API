﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class AddFKUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "Gender", "Position" },
                values: new object[] { new DateTime(2022, 3, 13, 21, 22, 31, 674, DateTimeKind.Local).AddTicks(233), new DateTime(2022, 3, 13, 21, 22, 31, 674, DateTimeKind.Local).AddTicks(241), 0, 0 });

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "tbl_user",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "tbl_user");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "tbl_user",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "Gender", "Position" },
                values: new object[] { new DateTime(2022, 3, 13, 18, 52, 0, 558, DateTimeKind.Local).AddTicks(4941), new DateTime(2022, 3, 13, 18, 52, 0, 558, DateTimeKind.Local).AddTicks(4957), " ", null });
        }
    }
}
