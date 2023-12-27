using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_new_BookId_PollBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "BookClubId" },
                values: new object[] { 1, 2053 });

            migrationBuilder.InsertData(
                table: "PollBook",
                columns: new[] { "BookId", "PollId" },
                values: new object[,]
                {
                    { 14, 1 },
                    { 15, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PollBook",
                keyColumns: new[] { "BookId", "PollId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "PollBook",
                keyColumns: new[] { "BookId", "PollId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
