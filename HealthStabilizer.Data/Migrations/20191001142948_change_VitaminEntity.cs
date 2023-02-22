using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class change_VitaminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Choline",
                table: "Vitamin",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VitaminB12",
                table: "Vitamin",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Choline",
                table: "Vitamin");

            migrationBuilder.DropColumn(
                name: "VitaminB12",
                table: "Vitamin");
        }
    }
}
