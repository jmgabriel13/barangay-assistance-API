using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class AddPurposeStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_purposeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purposeStatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 5, 17, 48, 51, 858, DateTimeKind.Local).AddTicks(7805), new DateTime(2022, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(5688), new DateTime(2022, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(2935), new DateTime(2023, 4, 5, 17, 48, 51, 859, DateTimeKind.Local).AddTicks(3797) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_purposeStatus");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateCreated", "TermFrom", "TermTo" },
                values: new object[] { new DateTime(2022, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(5481), new DateTime(2022, 4, 2, 20, 38, 57, 609, DateTimeKind.Local).AddTicks(301), new DateTime(2022, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(8494), new DateTime(2023, 4, 2, 20, 38, 57, 608, DateTimeKind.Local).AddTicks(8954) });
        }
    }
}
