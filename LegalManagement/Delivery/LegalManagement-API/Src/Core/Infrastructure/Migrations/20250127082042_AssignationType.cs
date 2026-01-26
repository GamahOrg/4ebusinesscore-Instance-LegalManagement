using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AssignationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropColumn(
                name: "ClientRequirments",
                table: "JedgementGrounds");

            migrationBuilder.RenameColumn(
                name: "OpponentRequirements",
                table: "JedgementGrounds",
                newName: "JudgementStatement");

            migrationBuilder.AddColumn<int>(
                name: "AssignationType",
                table: "SessionAssignees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CauseStageId",
                table: "JudgementGroundAttachments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextSession",
                table: "JedgementGrounds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CauseStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CauseAssigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CauseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignationType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseAssigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauseAssigns_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudgementRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JudgementGroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgementRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgementRequirements_JedgementGrounds_JudgementGroundId",
                        column: x => x.JudgementGroundId,
                        principalTable: "JedgementGrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauseAssigns_CauseId",
                table: "CauseAssigns",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgementRequirements_JudgementGroundId",
                table: "JudgementRequirements",
                column: "JudgementGroundId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropTable(
                name: "CauseAssigns");

            migrationBuilder.DropTable(
                name: "JudgementRequirements");

            migrationBuilder.DropColumn(
                name: "AssignationType",
                table: "SessionAssignees");

            migrationBuilder.DropColumn(
                name: "NextSession",
                table: "JedgementGrounds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CauseStages");

            migrationBuilder.RenameColumn(
                name: "JudgementStatement",
                table: "JedgementGrounds",
                newName: "OpponentRequirements");

            migrationBuilder.AlterColumn<Guid>(
                name: "CauseStageId",
                table: "JudgementGroundAttachments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientRequirments",
                table: "JedgementGrounds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
