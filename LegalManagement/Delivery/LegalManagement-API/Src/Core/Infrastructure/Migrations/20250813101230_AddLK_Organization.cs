using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddLKOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LK_OrganizatioId",
                table: "Litigants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LK_OrganizationId",
                table: "Litigants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LK_Organization",
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
                    table.PrimaryKey("PK_LK_Organization", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Litigants_LK_OrganizationId",
                table: "Litigants",
                column: "LK_OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Litigants_LK_Organization_LK_OrganizationId",
                table: "Litigants",
                column: "LK_OrganizationId",
                principalTable: "LK_Organization",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Litigants_LK_Organization_LK_OrganizationId",
                table: "Litigants");

            migrationBuilder.DropTable(
                name: "LK_Organization");

            migrationBuilder.DropIndex(
                name: "IX_Litigants_LK_OrganizationId",
                table: "Litigants");

            migrationBuilder.DropColumn(
                name: "LK_OrganizatioId",
                table: "Litigants");

            migrationBuilder.DropColumn(
                name: "LK_OrganizationId",
                table: "Litigants");
        }
    }
}
