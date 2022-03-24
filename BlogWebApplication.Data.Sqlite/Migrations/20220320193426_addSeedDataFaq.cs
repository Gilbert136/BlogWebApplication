using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Sqlite.Migrations
{
    public partial class addSeedDataFaq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 1, "Any skill is greatly embraced in this community. We need dedicated, motivated and committed individuals who are willing to sometimes sacrifice their time and energy. Having knowledge in programming or any technology related field will be a great bonus but do not worry we occasionally provide free technology classes to our community members which everyone can benefit from. Aside from that, we encourge everyone to join and contribute irrespective of the age or gender or whatever.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What are the skills I need to become a member?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 2, "Any skill is greatly embraced in this community. We need dedicated, motivated and committed individuals who are willing to sometimes sacrifice their time and energy. Having knowledge in programming or any technology related field will be a great bonus but do not worry we occasionally provide free technology classes to our community members which everyone can benefit from. Aside from that, we encourge everyone to join and contribute irrespective of the age or gender or whatever.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What are the skills I need to become a member?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
