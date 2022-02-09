using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Migrations
{
    public partial class updateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutContent",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubHeader",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutContent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubHeader",
                table: "AspNetUsers");
        }
    }
}
