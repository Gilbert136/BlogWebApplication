using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlogWebApplication.Data.Migrations
{
    public partial class addedProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Comment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Repository = table.Column<string>(type: "text", nullable: true),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<string>(type: "text", nullable: true),
                    ApproverId = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProjectId",
                table: "Comment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApproverId",
                table: "Project",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Project_ProjectId",
                table: "Comment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Project_ProjectId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ProjectId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");
        }
    }
}
