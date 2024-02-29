using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Entities.Migrations
{
    public partial class AddGenderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_gender", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 21, 17, 57, 40, 112, DateTimeKind.Local).AddTicks(7321), new DateTime(2022, 3, 21, 17, 57, 40, 112, DateTimeKind.Local).AddTicks(7328) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_gender");

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 3, 13, 21, 22, 31, 674, DateTimeKind.Local).AddTicks(233), new DateTime(2022, 3, 13, 21, 22, 31, 674, DateTimeKind.Local).AddTicks(241) });
        }
    }
}
