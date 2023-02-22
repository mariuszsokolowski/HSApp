using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class change_MineralEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nanganese",
                table: "Mineral",
                newName: "Sodium");

            migrationBuilder.RenameColumn(
                name: "Fluorine",
                table: "Mineral",
                newName: "Manganese");

            migrationBuilder.RenameColumn(
                name: "Chrome",
                table: "Mineral",
                newName: "Fluoride");

            migrationBuilder.RenameColumn(
                name: "Chlorine",
                table: "Mineral",
                newName: "Chromium");

            migrationBuilder.AddColumn<float>(
                name: "Chloride",
                table: "Mineral",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chloride",
                table: "Mineral");

            migrationBuilder.RenameColumn(
                name: "Sodium",
                table: "Mineral",
                newName: "Nanganese");

            migrationBuilder.RenameColumn(
                name: "Manganese",
                table: "Mineral",
                newName: "Fluorine");

            migrationBuilder.RenameColumn(
                name: "Fluoride",
                table: "Mineral",
                newName: "Chrome");

            migrationBuilder.RenameColumn(
                name: "Chromium",
                table: "Mineral",
                newName: "Chlorine");
        }
    }
}
