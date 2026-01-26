using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddAttchmentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttchmentName",
                table: "SessionAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttchmentName",
                table: "JudgementGroundAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttchmentName",
                table: "CauseStageNoteAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttchmentName",
                table: "CauseStageAttachments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttchmentName",
                table: "SessionAttachments");

            migrationBuilder.DropColumn(
                name: "AttchmentName",
                table: "JudgementGroundAttachments");

            migrationBuilder.DropColumn(
                name: "AttchmentName",
                table: "CauseStageNoteAttachments");

            migrationBuilder.DropColumn(
                name: "AttchmentName",
                table: "CauseStageAttachments");
        }
    }
}
