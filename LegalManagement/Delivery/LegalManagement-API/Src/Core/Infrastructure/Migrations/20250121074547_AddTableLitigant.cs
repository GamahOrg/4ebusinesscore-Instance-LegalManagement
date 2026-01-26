using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableLitigant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Litigants_Causes_CauseId",
                table: "Litigants");

            migrationBuilder.DropIndex(
                name: "IX_Litigants_CauseId",
                table: "Litigants");

            migrationBuilder.DropColumn(
                name: "CauseId",
                table: "Litigants");

            migrationBuilder.DropColumn(
                name: "Compliment",
                table: "Litigants");

            migrationBuilder.AddColumn<int>(
                name: "LK_AttachmentSourceId",
                table: "CauseStageAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CauseDate",
                table: "Causes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "causeStatus",
                table: "Causes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CauseLitigant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitigantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CauseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Compliment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseLitigant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauseLitigant_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauseLitigant_Litigants_LitigantId",
                        column: x => x.LitigantId,
                        principalTable: "Litigants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauseStageAttachments_LK_AttachmentSourceId",
                table: "CauseStageAttachments",
                column: "LK_AttachmentSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CauseLitigant_CauseId",
                table: "CauseLitigant",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_CauseLitigant_LitigantId",
                table: "CauseLitigant",
                column: "LitigantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CauseStageAttachments_LK_AttachmentSources_LK_AttachmentSourceId",
                table: "CauseStageAttachments",
                column: "LK_AttachmentSourceId",
                principalTable: "LK_AttachmentSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauseStageAttachments_LK_AttachmentSources_LK_AttachmentSourceId",
                table: "CauseStageAttachments");

            migrationBuilder.DropTable(
                name: "CauseLitigant");

            migrationBuilder.DropIndex(
                name: "IX_CauseStageAttachments_LK_AttachmentSourceId",
                table: "CauseStageAttachments");

            migrationBuilder.DropColumn(
                name: "LK_AttachmentSourceId",
                table: "CauseStageAttachments");

            migrationBuilder.DropColumn(
                name: "CauseDate",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "causeStatus",
                table: "Causes");

            migrationBuilder.AddColumn<Guid>(
                name: "CauseId",
                table: "Litigants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Compliment",
                table: "Litigants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Litigants_CauseId",
                table: "Litigants",
                column: "CauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Litigants_Causes_CauseId",
                table: "Litigants",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
