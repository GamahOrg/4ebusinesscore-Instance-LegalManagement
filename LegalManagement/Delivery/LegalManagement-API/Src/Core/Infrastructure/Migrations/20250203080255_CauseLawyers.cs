using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class CauseLawyers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalLawyer",
                table: "SessionAssignees");

            migrationBuilder.AddColumn<Guid>(
                name: "CauseLawyerId",
                table: "SessionAssignees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleJudement",
                table: "JedgementGrounds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CauseAssigns",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CauseLawyerId",
                table: "CauseAssigns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CauseLawyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    litigantStatus = table.Column<int>(type: "int", nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    lawyerStatus = table.Column<int>(type: "int", nullable: false),
                    LawyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lawyerType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseLawyers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionAssignees_CauseLawyerId",
                table: "SessionAssignees",
                column: "CauseLawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_CauseAssigns_CauseLawyerId",
                table: "CauseAssigns",
                column: "CauseLawyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CauseAssigns_CauseLawyers_CauseLawyerId",
                table: "CauseAssigns",
                column: "CauseLawyerId",
                principalTable: "CauseLawyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAssignees_CauseLawyers_CauseLawyerId",
                table: "SessionAssignees",
                column: "CauseLawyerId",
                principalTable: "CauseLawyers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauseAssigns_CauseLawyers_CauseLawyerId",
                table: "CauseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAssignees_CauseLawyers_CauseLawyerId",
                table: "SessionAssignees");

            migrationBuilder.DropTable(
                name: "CauseLawyers");

            migrationBuilder.DropIndex(
                name: "IX_SessionAssignees_CauseLawyerId",
                table: "SessionAssignees");

            migrationBuilder.DropIndex(
                name: "IX_CauseAssigns_CauseLawyerId",
                table: "CauseAssigns");

            migrationBuilder.DropColumn(
                name: "CauseLawyerId",
                table: "SessionAssignees");

            migrationBuilder.DropColumn(
                name: "TitleJudement",
                table: "JedgementGrounds");

            migrationBuilder.DropColumn(
                name: "CauseLawyerId",
                table: "CauseAssigns");

            migrationBuilder.AddColumn<string>(
                name: "ExternalLawyer",
                table: "SessionAssignees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CauseAssigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
