using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class EditHistoryCauseStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CauseStageId",
                table: "CauseHistorys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CauseHistorys_CauseStageId",
                table: "CauseHistorys",
                column: "CauseStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CauseHistorys_CauseStages_CauseStageId",
                table: "CauseHistorys",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauseHistorys_CauseStages_CauseStageId",
                table: "CauseHistorys");

            migrationBuilder.DropIndex(
                name: "IX_CauseHistorys_CauseStageId",
                table: "CauseHistorys");

            migrationBuilder.DropColumn(
                name: "CauseStageId",
                table: "CauseHistorys");
        }
    }
}
