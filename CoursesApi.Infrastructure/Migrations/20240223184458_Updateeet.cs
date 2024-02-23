using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateeet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhatRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Browser", "IPAddress", "VisitTime", "WhatRequest" },
                values: new object[] { 1, "Google", "127.10.11.24:0000", new DateTime(2024, 2, 23, 20, 44, 57, 903, DateTimeKind.Local).AddTicks(7375), "Course" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
