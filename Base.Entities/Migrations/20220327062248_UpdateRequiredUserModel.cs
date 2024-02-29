using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class UpdateRequiredUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "tbl_user",
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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 27, 14, 22, 46, 726, DateTimeKind.Local).AddTicks(4024), new DateTime(2022, 3, 27, 14, 22, 46, 726, DateTimeKind.Local).AddTicks(4073) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 27, 14, 20, 13, 937, DateTimeKind.Local).AddTicks(9620), new DateTime(2022, 3, 27, 14, 20, 13, 937, DateTimeKind.Local).AddTicks(9676) });
        }
    }
}
