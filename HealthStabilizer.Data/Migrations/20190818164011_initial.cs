using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStabilizer.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mineral",
                columns: table => new
                {
                    MineralId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Potassium = table.Column<float>(nullable: false),
                    Chlorine = table.Column<float>(nullable: false),
                    Calcium = table.Column<float>(nullable: false),
                    Phosphorus = table.Column<float>(nullable: false),
                    Magnesium = table.Column<float>(nullable: false),
                    Iron = table.Column<float>(nullable: false),
                    Zinc = table.Column<float>(nullable: false),
                    Copper = table.Column<float>(nullable: false),
                    Nanganese = table.Column<float>(nullable: false),
                    Fluorine = table.Column<float>(nullable: false),
                    Selenium = table.Column<float>(nullable: false),
                    Chrome = table.Column<float>(nullable: false),
                    Molybdenum = table.Column<float>(nullable: false),
                    Iodine = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mineral", x => x.MineralId);
                });

            migrationBuilder.CreateTable(
                name: "Vitamin",
                columns: table => new
                {
                    VitaminId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VitaminA = table.Column<float>(nullable: false),
                    VitaminD = table.Column<float>(nullable: false),
                    VitaminE = table.Column<float>(nullable: false),
                    VitaminK = table.Column<float>(nullable: false),
                    VitaminC = table.Column<float>(nullable: false),
                    Thiamine = table.Column<float>(nullable: false),
                    Riboflavin = table.Column<float>(nullable: false),
                    Niacin = table.Column<float>(nullable: false),
                    VitaminB6 = table.Column<float>(nullable: false),
                    FolicAcid = table.Column<float>(nullable: false),
                    Biotin = table.Column<float>(nullable: false),
                    PanotehnicAcid = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitamin", x => x.VitaminId);
                });

            migrationBuilder.CreateTable(
                name: "DailyIntake",
                columns: table => new
                {
                    DailyIntakeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Calories = table.Column<float>(nullable: false),
                    Carbs = table.Column<float>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    Protein = table.Column<float>(nullable: false),
                    VitaminId = table.Column<int>(nullable: false),
                    MineralId = table.Column<int>(nullable: false),
                    ForUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyIntake", x => x.DailyIntakeId);
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

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    QrCode = table.Column<string>(nullable: true),
                    WeightPerPiece = table.Column<float>(nullable: true),
                    PiecesInPackage = table.Column<float>(nullable: true),
                    MineralId = table.Column<int>(nullable: false),
                    VitaminId = table.Column<int>(nullable: false),
                    ForUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Food_Mineral_MineralId",
                        column: x => x.MineralId,
                        principalTable: "Mineral",
                        principalColumn: "MineralId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Vitamin_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Vitamin",
                        principalColumn: "VitaminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_MineralId",
                table: "DailyIntake",
                column: "MineralId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntake_VitaminId",
                table: "DailyIntake",
                column: "VitaminId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MineralId",
                table: "Food",
                column: "MineralId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_VitaminId",
                table: "Food",
                column: "VitaminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyIntake");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Mineral");

            migrationBuilder.DropTable(
                name: "Vitamin");
        }
    }
}
