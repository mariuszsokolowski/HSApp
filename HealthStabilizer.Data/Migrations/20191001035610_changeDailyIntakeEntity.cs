using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class changeDailyIntakeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ForUserId",
                table: "DailyIntake",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForUserId1",
                table: "DailyIntake",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_ForUserId1",
                table: "DailyIntake",
                column: "ForUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyIntake_AspNetUsers_ForUserId1",
                table: "DailyIntake",
                column: "ForUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyIntake_AspNetUsers_ForUserId1",
                table: "DailyIntake");

            migrationBuilder.DropIndex(
                name: "IX_DailyIntake_ForUserId1",
                table: "DailyIntake");

            migrationBuilder.DropColumn(
                name: "ForUserId1",
                table: "DailyIntake");

            migrationBuilder.AlterColumn<int>(
                name: "ForUserId",
                table: "DailyIntake",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
