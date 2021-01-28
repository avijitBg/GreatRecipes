using Microsoft.EntityFrameworkCore.Migrations;

namespace GreatRecipes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Review_ReviewId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ReviewId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ReviewerName",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Reviews",
                newName: "RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Review",
                newName: "Stars");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerName",
                table: "Review",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ReviewId",
                table: "Recipes",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Review_ReviewId",
                table: "Recipes",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
