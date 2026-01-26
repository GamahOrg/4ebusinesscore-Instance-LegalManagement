using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class ELibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAssignees_Sessions_SessionId",
                table: "SessionAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionAssignees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudy",
                table: "LK_Stages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CauseStageNoteAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LKAttachmentSourceId = table.Column<int>(name: "LK_AttachmentSourceId", type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseStageNoteAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauseStageNoteAttachments_LK_AttachmentSources_LK_AttachmentSourceId",
                        column: x => x.LKAttachmentSourceId,
                        principalTable: "LK_AttachmentSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauseStageNoteAttachments_SessionNotes_SessionNoteId",
                        column: x => x.SessionNoteId,
                        principalTable: "SessionNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ELibraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ELibraries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauseStageNoteAttachments_LK_AttachmentSourceId",
                table: "CauseStageNoteAttachments",
                column: "LK_AttachmentSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CauseStageNoteAttachments_SessionNoteId",
                table: "CauseStageNoteAttachments",
                column: "SessionNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAssignees_Sessions_SessionId",
                table: "SessionAssignees",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAssignees_Sessions_SessionId",
                table: "SessionAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.DropTable(
                name: "CauseStageNoteAttachments");

            migrationBuilder.DropTable(
                name: "ELibraries");

            migrationBuilder.DropColumn(
                name: "IsStudy",
                table: "LK_Stages");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionAssignees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAssignees_Sessions_SessionId",
                table: "SessionAssignees",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
