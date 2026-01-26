using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class createLKClassificationTypeELibraries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LK_ClassificationTypeELibraryId",
                table: "ELibraries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LK_ClassificationTypeELibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LK_ClassificationTypeELibraries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ELibraries_LK_ClassificationTypeELibraryId",
                table: "ELibraries",
                column: "LK_ClassificationTypeELibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ELibraries_LK_ClassificationTypeELibraries_LK_ClassificationTypeELibraryId",
                table: "ELibraries",
                column: "LK_ClassificationTypeELibraryId",
                principalTable: "LK_ClassificationTypeELibraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ELibraries_LK_ClassificationTypeELibraries_LK_ClassificationTypeELibraryId",
                table: "ELibraries");

            migrationBuilder.DropTable(
                name: "LK_ClassificationTypeELibraries");

            migrationBuilder.DropIndex(
                name: "IX_ELibraries_LK_ClassificationTypeELibraryId",
                table: "ELibraries");

            migrationBuilder.DropColumn(
                name: "LK_ClassificationTypeELibraryId",
                table: "ELibraries");
        }
    }
}
