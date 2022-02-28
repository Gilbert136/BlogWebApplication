using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Migrations
{
    public partial class addedColsAnonymousUsernameComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnonymousUserName",
                table: "Comment",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnonymousUserName",
                table: "Comment");
        }
    }
}
