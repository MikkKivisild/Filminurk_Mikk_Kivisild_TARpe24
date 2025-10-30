using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ActorsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fish",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortraitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstActed = table.Column<DateOnly>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorID);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentScore = table.Column<int>(type: "int", nullable: false),
                    IsHelpful = table.Column<int>(type: "int", nullable: false),
                    IsHarmful = table.Column<int>(type: "int", nullable: false),
                    CommentCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentModifieddAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_UserComments_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_MovieID",
                table: "UserComments",
                column: "MovieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.AlterColumn<string>(
                name: "Fish",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
