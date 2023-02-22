using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class addBaseGoalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseGoal",
                columns: table => new
                {
                    BaseGoalsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<float>(nullable: false),
                    Carbs = table.Column<float>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    Protein = table.Column<float>(nullable: false),
                    VitaminId = table.Column<int>(nullable: false),
                    MineralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseGoal", x => x.BaseGoalsId);
                    table.ForeignKey(
                        name: "FK_BaseGoal_Mineral_MineralId",
                        column: x => x.MineralId,
                        principalTable: "Mineral",
                        principalColumn: "MineralId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseGoal_Vitamin_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Vitamin",
                        principalColumn: "VitaminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoal_MineralId",
                table: "BaseGoal",
                column: "MineralId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoal_VitaminId",
                table: "BaseGoal",
                column: "VitaminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseGoal");
        }
    }
}
