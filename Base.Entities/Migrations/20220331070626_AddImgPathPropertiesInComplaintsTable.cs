using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class AddImgPathPropertiesInComplaintsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProofImgPath",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationImgPath",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 6, 25, 666, DateTimeKind.Local).AddTicks(6421), new DateTime(2022, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(4481), new DateTime(2022, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(3176), new DateTime(2023, 3, 31, 15, 6, 25, 667, DateTimeKind.Local).AddTicks(3752) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofImgPath",
                table: "tbl_complaints");

            migrationBuilder.DropColumn(
                name: "VerificationImgPath",
                table: "tbl_complaints");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(6640), new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(9825), new DateTime(2022, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(8705), new DateTime(2023, 3, 30, 19, 28, 22, 228, DateTimeKind.Local).AddTicks(9132) });
        }
    }
}
