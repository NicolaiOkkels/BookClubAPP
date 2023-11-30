using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_rating_dummy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "BookId", "MemberId", "Id", "Score" },
                values: new object[,]
                {
                    { 1, 1, 1, 5 },
                    { 2, 1, 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "BookId", "MemberId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "BookId", "MemberId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
