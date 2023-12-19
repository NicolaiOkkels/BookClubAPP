using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changed_values_dummydata_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "MemberId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "MemberId",
                value: 3);
        }
    }
}
