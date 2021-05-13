using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkout.Dal.Migrations
{
    public partial class categoryentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 880, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1479), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6eb0652a-7001-4bf1-a632-f4aa905ec6e5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7ac6a02c-1f31-4e6a-a917-e0a20fc28122");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4c885252-e07e-45f7-a45c-97a33ce8ebd5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 758, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 761, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 761, DateTimeKind.Unspecified).AddTicks(6406), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 761, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 761, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 9, 44, 58, 761, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "20bd6768-9264-4e0a-905b-515aa75855c0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ae4efa6b-1304-4a1d-ab76-b0e4e2de6e11");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f1df6d0f-52e2-41d8-bb6c-54af7a5d2f75");
        }
    }
}
