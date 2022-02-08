using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Migrations
{
    public partial class addedColsComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_PosterId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "PosterId",
                table: "Comment",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PosterId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comment",
                newName: "PosterId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                newName: "IX_Comment_PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_PosterId",
                table: "Comment",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
