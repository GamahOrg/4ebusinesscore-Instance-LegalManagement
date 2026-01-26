using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveJudgementAttchmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropIndex(
                name: "IX_JudgementGroundAttachments_CauseStageId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "JudgementGroundAttachments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "JudgementGroundAttachments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JudgementGroundAttachments_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_CauseStages_CauseStageId",
                table: "JudgementGroundAttachments",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id");
        }
    }
}
