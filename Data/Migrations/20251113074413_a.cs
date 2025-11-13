using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentUserID",
                table: "UserComments",
                newName: "CommenterUserID");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryCreatedAt",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryModifiedAt",
                table: "Actors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryCreatedAt",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "EntryModifiedAt",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "CommenterUserID",
                table: "UserComments",
                newName: "CommentUserID");
        }
    }
}
