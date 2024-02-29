using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class EditRemarksChangeToStatusComplaintsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "tbl_complaints");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tbl_complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 5, 19, 45, 38, 254, DateTimeKind.Local).AddTicks(4955), new DateTime(2022, 4, 5, 19, 45, 38, 254, DateTimeKind.Local).AddTicks(9123), new DateTime(2022, 4, 5, 19, 45, 38, 254, DateTimeKind.Local).AddTicks(7716), new DateTime(2023, 4, 5, 19, 45, 38, 254, DateTimeKind.Local).AddTicks(8142) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbl_complaints");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "tbl_complaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 5, 17, 48, 51, 858, DateTimeKind.Local).AddTicks(7805), new DateTime(2022, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(5688), new DateTime(2022, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(2935), new DateTime(2023, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(3797) });
        }
    }
}
