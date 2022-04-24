using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.Data.Sqlite.Migrations
{
    public partial class seedForProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 1, false, null, "Small-Scale Business", "Organizational Social and Interactive Application System is a browser-based application system which uses web technologies that is accessible on an intranet architecture. The application can be accessed using a web browser on a PC, mobile phone and etc. The application is developed using open source web technologies like HTML, CSS, typescript for the front-end and nodeJS, JavaScript and mongoDB for the back-end.", new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/Organizational-Social-And-Interactive-Application-System-OSIAS-.git", "[]", "Organizational Social And Interactive Application (OSIAS)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 2, false, null, "Education", null, new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/QuizApplication.git", "[]", "Quiz Application System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 3, false, null, "Small-Scale Business", null, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/GasMe.Server.git", "[]", "GasMe Application System - Backend", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 4, false, null, "Small-Scale Business", null, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/GasMe.ReactNative.git", "[]", "GasMe Application System - Frontend", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 5, false, null, "Education", null, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/StudentManagementSystem.git", "[]", "Student Management System - Backend", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 6, false, null, "Education", null, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/StudentManagementSystem.Web.git", "[]", "Student Management System - Frontend", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 7, false, null, "Environment", null, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/CleanTheEnvironment.git", "[]", "Clean The Environment Management System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 8, false, null, "Education", null, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/DiaryApp.git", "[]", "Diary Application System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Approved", "ApproverId", "Category", "Content", "CreatedOn", "CreatorId", "Published", "Repository", "Tags", "Title", "UpdatedOn" },
                values: new object[] { 9, false, null, "Education", null, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "https://github.com/Gilbert136/SchoolBusTransportationSystem.git", "[]", "School Bus Transportation Application System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
