using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkout.Dal.Migrations
{
    public partial class testdataComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DisplayName", "Email" },
                values: new object[] { 1, null, "Megverj Elek", "megverjelek@example.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DisplayName", "Email" },
                values: new object[] { 2, null, "Egyip Tomi", "egyiptomi@example.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DisplayName", "Email" },
                values: new object[] { 3, null, "Fütty Imre", "füttyimre@example.com" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text", "UserID", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 138, DateTimeKind.Unspecified).AddTicks(6486), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 1, 1 },
                    { 6, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 2, 2 },
                    { 5, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 2, 1 },
                    { 3, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 3, 3 },
                    { 4, new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 2, 0, 0, 0)), "Ez aztán durva edzés terv", 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
