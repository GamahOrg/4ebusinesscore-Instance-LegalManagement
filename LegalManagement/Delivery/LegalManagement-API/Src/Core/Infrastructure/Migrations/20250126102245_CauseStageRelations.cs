using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class CauseStageRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "SessionAttachments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "SessionAssignees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "JudgementGroundAttachments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "JedgementGrounds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SessionNotes_CauseStageId",
                table: "SessionNotes",
                column: "CauseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttachments_CauseStageId",
                table: "SessionAttachments",
                column: "CauseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAssignees_CauseStageId",
                table: "SessionAssignees",
                column: "CauseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgementGroundAttachments_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_JedgementGrounds_CauseStageId",
                table: "JedgementGrounds",
                column: "CauseStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_JedgementGrounds_CauseStages_CauseStageId",
                table: "JedgementGrounds",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAssignees_CauseStages_CauseStageId",
                table: "SessionAssignees",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttachments_CauseStages_CauseStageId",
                table: "SessionAttachments",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_CauseStages_CauseStageId",
                table: "SessionNotes",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JedgementGrounds_CauseStages_CauseStageId",
                table: "JedgementGrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAssignees_CauseStages_CauseStageId",
                table: "SessionAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttachments_CauseStages_CauseStageId",
                table: "SessionAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_CauseStages_CauseStageId",
                table: "SessionNotes");

            migrationBuilder.DropIndex(
                name: "IX_SessionNotes_CauseStageId",
                table: "SessionNotes");

            migrationBuilder.DropIndex(
                name: "IX_SessionAttachments_CauseStageId",
                table: "SessionAttachments");

            migrationBuilder.DropIndex(
                name: "IX_SessionAssignees_CauseStageId",
                table: "SessionAssignees");

            migrationBuilder.DropIndex(
                name: "IX_JudgementGroundAttachments_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropIndex(
                name: "IX_JedgementGrounds_CauseStageId",
                table: "JedgementGrounds");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "SessionNotes");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "SessionAttachments");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "SessionAssignees");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "JedgementGrounds");
        }
    }
}
