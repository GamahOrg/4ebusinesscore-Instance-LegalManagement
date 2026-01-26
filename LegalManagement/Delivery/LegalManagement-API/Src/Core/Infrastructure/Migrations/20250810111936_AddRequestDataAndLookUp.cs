using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestDataAndLookUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LK_TypeJudiciaryId",
                table: "Causes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "Causes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LK_TypeJudiciary",
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
                    table.PrimaryKey("PK_LK_TypeJudiciary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Causes_LK_TypeJudiciaryId",
                table: "Causes",
                column: "LK_TypeJudiciaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_LK_TypeJudiciary_LK_TypeJudiciaryId",
                table: "Causes",
                column: "LK_TypeJudiciaryId",
                principalTable: "LK_TypeJudiciary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_LK_TypeJudiciary_LK_TypeJudiciaryId",
                table: "Causes");

            migrationBuilder.DropTable(
                name: "LK_TypeJudiciary");

            migrationBuilder.DropIndex(
                name: "IX_Causes_LK_TypeJudiciaryId",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "LK_TypeJudiciaryId",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "Causes");
        }
    }
}
