using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class added_memberid_to_bookclub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "BookClubs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: null);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "MemberId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_MemberId",
                table: "BookClubs",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubs_Members_MemberId",
                table: "BookClubs",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookClubs_Members_MemberId",
                table: "BookClubs");

            migrationBuilder.DropIndex(
                name: "IX_BookClubs_MemberId",
                table: "BookClubs");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "BookClubs");
        }
    }
}
