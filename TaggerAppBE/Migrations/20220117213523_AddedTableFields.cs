using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaggerAppBE.Migrations
{
    public partial class AddedTableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedCategories",
                table: "LikedCategories");

            migrationBuilder.DropIndex(
                name: "IX_LikedCategories_ProfileId",
                table: "LikedCategories");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Posts",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "LikedCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reviews",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Posts",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedCategories",
                table: "LikedCategories",
                columns: new[] { "ProfileId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_LikedCategories_CategoryId",
                table: "LikedCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCategories_Categories_CategoryId",
                table: "LikedCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCategories_Categories_CategoryId",
                table: "LikedCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedCategories",
                table: "LikedCategories");

            migrationBuilder.DropIndex(
                name: "IX_LikedCategories_CategoryId",
                table: "LikedCategories");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Posts",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "LikedCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Posts",
                table: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedCategories",
                table: "LikedCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FollowedTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowedTags_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedCategories_ProfileId",
                table: "LikedCategories",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedTags_ProfileId",
                table: "FollowedTags",
                column: "ProfileId");
        }
    }
}
