using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class JudgmentReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JedgementGrounds_CauseStages_CauseStageId",
                table: "JedgementGrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_JedgementGrounds_LK_Judgements_LK_JudgementId",
                table: "JedgementGrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_JedgementGrounds_Sessions_SessionId",
                table: "JedgementGrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_JedgementGrounds_JedgementGroundId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementRequirements_JedgementGrounds_JudgementGroundId",
                table: "JudgementRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JedgementGrounds",
                table: "JedgementGrounds");

            migrationBuilder.RenameTable(
                name: "JedgementGrounds",
                newName: "JudgementGroundReport");

            migrationBuilder.RenameIndex(
                name: "IX_JedgementGrounds_SessionId",
                table: "JudgementGroundReport",
                newName: "IX_JudgementGroundReport_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_JedgementGrounds_LK_JudgementId",
                table: "JudgementGroundReport",
                newName: "IX_JudgementGroundReport_LK_JudgementId");

            migrationBuilder.RenameIndex(
                name: "IX_JedgementGrounds_CauseStageId",
                table: "JudgementGroundReport",
                newName: "IX_JudgementGroundReport_CauseStageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JudgementGroundReport",
                table: "JudgementGroundReport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "JudgmentReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JudgmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JudgmentDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CauseStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgmentReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgmentReferences_CauseStages_CauseStageId",
                        column: x => x.CauseStageId,
                        principalTable: "CauseStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JudgmentReferences_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgmentReferences_CauseStageId",
                table: "JudgmentReferences",
                column: "CauseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgmentReferences_SessionId",
                table: "JudgmentReferences",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_JudgementGroundReport_JedgementGroundId",
                table: "JudgementGroundAttachments",
                column: "JedgementGroundId",
                principalTable: "JudgementGroundReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundReport_CauseStages_CauseStageId",
                table: "JudgementGroundReport",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundReport_LK_Judgements_LK_JudgementId",
                table: "JudgementGroundReport",
                column: "LK_JudgementId",
                principalTable: "LK_Judgements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundReport_Sessions_SessionId",
                table: "JudgementGroundReport",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementRequirements_JudgementGroundReport_JudgementGroundId",
                table: "JudgementRequirements",
                column: "JudgementGroundId",
                principalTable: "JudgementGroundReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundAttachments_JudgementGroundReport_JedgementGroundId",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundReport_CauseStages_CauseStageId",
                table: "JudgementGroundReport");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundReport_LK_Judgements_LK_JudgementId",
                table: "JudgementGroundReport");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementGroundReport_Sessions_SessionId",
                table: "JudgementGroundReport");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgementRequirements_JudgementGroundReport_JudgementGroundId",
                table: "JudgementRequirements");

            migrationBuilder.DropTable(
                name: "JudgmentReferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JudgementGroundReport",
                table: "JudgementGroundReport");

            migrationBuilder.RenameTable(
                name: "JudgementGroundReport",
                newName: "JedgementGrounds");

            migrationBuilder.RenameIndex(
                name: "IX_JudgementGroundReport_SessionId",
                table: "JedgementGrounds",
                newName: "IX_JedgementGrounds_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_JudgementGroundReport_LK_JudgementId",
                table: "JedgementGrounds",
                newName: "IX_JedgementGrounds_LK_JudgementId");

            migrationBuilder.RenameIndex(
                name: "IX_JudgementGroundReport_CauseStageId",
                table: "JedgementGrounds",
                newName: "IX_JedgementGrounds_CauseStageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JedgementGrounds",
                table: "JedgementGrounds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JedgementGrounds_CauseStages_CauseStageId",
                table: "JedgementGrounds",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JedgementGrounds_LK_Judgements_LK_JudgementId",
                table: "JedgementGrounds",
                column: "LK_JudgementId",
                principalTable: "LK_Judgements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JedgementGrounds_Sessions_SessionId",
                table: "JedgementGrounds",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementGroundAttachments_JedgementGrounds_JedgementGroundId",
                table: "JudgementGroundAttachments",
                column: "JedgementGroundId",
                principalTable: "JedgementGrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgementRequirements_JedgementGrounds_JudgementGroundId",
                table: "JudgementRequirements",
                column: "JudgementGroundId",
                principalTable: "JedgementGrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
