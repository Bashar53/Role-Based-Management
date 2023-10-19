using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLoginDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDB",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDB", x => x.RegNo);
                });

            migrationBuilder.InsertData(
                table: "LoginDB",
                columns: new[] { "RegNo", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Pass", "Role", "Status" },
                values: new object[] { "C183077", new DateTimeOffset(new DateTime(2023, 10, 5, 12, 14, 31, 105, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 6, 0, 0, 0)), "1", new DateTimeOffset(new DateTime(2023, 10, 5, 12, 14, 31, 105, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 6, 0, 0, 0)), null, "12345", "student", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDB");
        }
    }
}
