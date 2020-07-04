using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumZawody.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "IdPlayer", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2010, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "IdPlayer", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(2000, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazik", "Nowak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "IdPlayer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "IdPlayer",
                keyValue: 2);
        }
    }
}
