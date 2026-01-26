#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class EditHistoryRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauseHistorys_CauseStages_CauseStageId",
                table: "CauseHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.DropIndex(
                name: "IX_CauseHistorys_CauseStageId",
                table: "CauseHistorys");

            migrationBuilder.RenameColumn(
                name: "CauseStageId",
                table: "CauseHistorys",
                newName: "RecordId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "CauseHistorys",
                newName: "CauseStageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_CauseHistorys_CauseStageId",
                table: "CauseHistorys",
                column: "CauseStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CauseHistorys_CauseStages_CauseStageId",
                table: "CauseHistorys",
                column: "CauseStageId",
                principalTable: "CauseStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }
    }
}
