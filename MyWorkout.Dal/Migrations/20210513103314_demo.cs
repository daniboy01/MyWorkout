using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkout.Dal.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 12, 33, 13, 839, DateTimeKind.Unspecified).AddTicks(775), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 12, 33, 13, 842, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 12, 33, 13, 842, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2021, 5, 13, 12, 33, 13, 842, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "555ae822-84d0-4165-be6d-41b38b4135b0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "65083fbe-52a1-4feb-8b79-5c0ce57266eb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, null, "4c885252-e07e-45f7-a45c-97a33ce8ebd5", "Fütty Imre", "füttyimre@example.com", false, false, null, null, null, null, null, false, null, false, null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text", "UserID", "WorkoutPlanId" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 3, 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text", "UserID", "WorkoutPlanId" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2021, 5, 13, 11, 55, 57, 884, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 3, 1 });
        }
    }
}
