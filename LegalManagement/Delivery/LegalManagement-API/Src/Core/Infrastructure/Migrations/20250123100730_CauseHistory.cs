using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class CauseHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CauseHistorys",
                newName: "TableName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CauseHistorys",
                newName: "OldValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "SessionNotes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "CauseHistorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "CauseHistorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "FK_SessionNotes_Sessions_SessionId",
                table: "SessionNotes");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "CauseHistorys");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "CauseHistorys");

            migrationBuilder.RenameColumn(
                name: "TableName",
                table: "CauseHistorys",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "OldValue",
                table: "CauseHistorys",
                newName: "Description");

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
    }
}
