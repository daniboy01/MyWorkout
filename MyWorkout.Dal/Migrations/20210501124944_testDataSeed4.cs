using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkout.Dal.Migrations
{
    public partial class testDataSeed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "WorkoutPlans",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Own Weight Challenge");

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Weight Challenge");

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Ultimate bodyshock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "WorkoutPlans");
        }
    }
}
