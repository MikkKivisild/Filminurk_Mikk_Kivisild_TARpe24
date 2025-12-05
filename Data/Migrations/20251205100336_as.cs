using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsHelpful",
                table: "UserComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IsHarmful",
                table: "UserComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteListID",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteLists",
                columns: table => new
                {
                    FavoriteListID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListBelongsToUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMovieOrActor = table.Column<bool>(type: "bit", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    ListCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteLists", x => x.FavoriteListID);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ImageID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FavoriteListID",
                table: "Movies",
                column: "FavoriteListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_FavoriteLists_FavoriteListID",
                table: "Movies",
                column: "FavoriteListID",
                principalTable: "FavoriteLists",
                principalColumn: "FavoriteListID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FavoriteLists_FavoriteListID",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "FavoriteLists");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FavoriteListID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FavoriteListID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "IsHelpful",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsHarmful",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
