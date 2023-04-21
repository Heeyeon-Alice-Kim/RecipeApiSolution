using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApi.Data.RecipeMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Serve = table.Column<int>(type: "INTEGER", nullable: false),
                    Calorie = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Ingredient = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Spicy = table.Column<string>(type: "TEXT", nullable: true),
                    LOD = table.Column<string>(type: "TEXT", nullable: true),
                    FoodCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_FoodCategories_FoodCategoryID",
                        column: x => x.FoodCategoryID,
                        principalTable: "FoodCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_FoodCategoryID",
                table: "FoodRecipes",
                column: "FoodCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecipes");

            migrationBuilder.DropTable(
                name: "FoodCategories");
        }
    }
}
