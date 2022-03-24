using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Sqlite.Migrations
{
    public partial class updateSeedDataFaq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Head" },
                values: new object[] { "We are a community of software developers, engineers and designers with the passion of improving our communities through technology. Our main activity is in software development with strict focus in education, the environment and small-scale businesses.", "What is the purpose of this Organization?" });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 3, "No, nobody gets paid. Your contribution goes a long way in helping solve problems in our community which in turn helps us and our next generation live a better life. Most of our activies here is strictly to give back to the community.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Will I be paid for contributing to this community?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 4, "The community and everyone who want to be part of the community. Majority of the our projects are hosted on open source platforms which makes it automatically available to everyone who wants to contribute. Note, we do not permit the use of our property for profit benefits. Doing so will attract punishment.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Who are the beneficiaries of our contribution?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 5, "We seek to launch at least one software application in each of the project categories at the end of each year. We can only achieve this with your help.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What does the organization seeks to achieve in the next year?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 6, "Currently, The organization started with only 500 cedis as its capital which is provided solely by the founder. In the future, we hope to consider other funding options.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Who is funding the organization?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 7, "I will say that finding enough right people to join the organization has been a real challenge. I partly believe that since there are no financial motivation, majority gets discouraged. I am hoping that, there will be a time where things will be better. Another current challenge is at the deployment stage. There are few free online hosts and most are very limited in processing capacity and as a results limits our output. There are also instances where there are no computing devices available to deploy the software.We once visited a school in a community in Ghana.We wanted to deploy an application which helps stage one students to learn how to count numbers, because there were no computers available in the school.We were not able to achieve our target.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What are some of the organization's challenges?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "Id", "Body", "CreatedOn", "Head", "UpdatedOn" },
                values: new object[] { 8, "We seeks to become the main drivers of change in our community through technology. We hope in the next five years, we will be able to empower the youths and other individuals in our community with technology by collaboration with other stakeholders to provide computers and other mobiles devices to help set up an Information Communication Technology(ICT) Center in every community in Ghana. We can only achieve this with your help.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "What is the organization's long term goals?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Faq",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Head" },
                values: new object[] { "Any skill is greatly embraced in this community. We need dedicated, motivated and committed individuals who are willing to sometimes sacrifice their time and energy. Having knowledge in programming or any technology related field will be a great bonus but do not worry we occasionally provide free technology classes to our community members which everyone can benefit from. Aside from that, we encourge everyone to join and contribute irrespective of the age or gender or whatever.", "What are the skills I need to become a member?" });
        }
    }
}
