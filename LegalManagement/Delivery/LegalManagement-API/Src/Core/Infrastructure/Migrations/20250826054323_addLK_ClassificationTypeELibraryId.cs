using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class addLKClassificationTypeELibraryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LK_ClassificationTypeELibrariesId",
                table: "Causes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LK_ClassificationTypeELibraryId",
                table: "Causes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Causes_LK_ClassificationTypeELibrariesId",
                table: "Causes",
                column: "LK_ClassificationTypeELibrariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_LK_ClassificationTypeELibraries_LK_ClassificationTypeELibrariesId",
                table: "Causes",
                column: "LK_ClassificationTypeELibrariesId",
                principalTable: "LK_ClassificationTypeELibraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_LK_ClassificationTypeELibraries_LK_ClassificationTypeELibrariesId",
                table: "Causes");

            migrationBuilder.DropIndex(
                name: "IX_Causes_LK_ClassificationTypeELibrariesId",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "LK_ClassificationTypeELibrariesId",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "LK_ClassificationTypeELibraryId",
                table: "Causes");
        }
    }
}
