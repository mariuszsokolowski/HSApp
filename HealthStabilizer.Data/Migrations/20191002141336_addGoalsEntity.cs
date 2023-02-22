using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class addGoalsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyIntake");

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<float>(nullable: false),
                    Carbs = table.Column<float>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    Protein = table.Column<float>(nullable: false),
                    ForUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalsId);
                    table.ForeignKey(
                        name: "FK_Goals_AspNetUsers_ForUserId",
                        column: x => x.ForUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ForUserId",
                table: "Goals",
                column: "ForUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.CreateTable(
                name: "DailyIntake",
                columns: table => new
                {
                    DailyIntakeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<float>(nullable: false),
                    Carbs = table.Column<float>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    ForUserId = table.Column<int>(nullable: false),
                    ForUserId1 = table.Column<string>(nullable: true),
                    MineralId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Protein = table.Column<float>(nullable: false),
                    VitaminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyIntake", x => x.DailyIntakeId);
                    table.ForeignKey(
                        name: "FK_DailyIntake_AspNetUsers_ForUserId1",
                        column: x => x.ForUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyIntake_Mineral_MineralId",
                        column: x => x.MineralId,
                        principalTable: "Mineral",
                        principalColumn: "MineralId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyIntake_Vitamin_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Vitamin",
                        principalColumn: "VitaminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_ForUserId1",
                table: "DailyIntake",
                column: "ForUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_MineralId",
                table: "DailyIntake",
                column: "MineralId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_VitaminId",
                table: "DailyIntake",
                column: "VitaminId");
        }
    }
}
