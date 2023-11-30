using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class populateDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookClubs",
                columns: new[] { "Id", "Description", "Name", "Region", "Type" },
                values: new object[,]
                {
                    { 1, "Description of Book Club 1", "Book Club 1", "North America", "Fiction" },
                    { 2, "Description of Book Club 2", "Book Club 2", "Europe", "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookClubId", "Description", "ISBN", "Identifier", "Language", "Pages", "PublicationYear", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, null, "Description of Book 1", "978-3-16-148410-0", "A123", "English", "300", 2020, "Publisher 1", "Sample Book 1" },
                    { 2, null, "Description of Book 2", "978-1-23-456789-7", "B456", "Spanish", "250", 2021, "Publisher 2", "Sample Book 2" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe" },
                    { 2, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Member" },
                    { 2, "Book Club Owner" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "BookClubId", "MemberId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "BookClubId", "MemberId", "RoleId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "BookClubId", "MemberId", "RoleId" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
