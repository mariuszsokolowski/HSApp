using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class changeFoodEntityAdd_Protein_Fat_Carbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Carbs",
                table: "Food",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fat",
                table: "Food",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Protein",
                table: "Food",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Food");
        }
    }
}
