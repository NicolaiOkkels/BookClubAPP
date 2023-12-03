using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removed_membership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookClubs_BookClubId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookClubId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookClubId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookClubs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: null);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_BookId",
                table: "BookClubs",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubs_Books_BookId",
                table: "BookClubs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookClubs_Books_BookId",
                table: "BookClubs");

            migrationBuilder.DropIndex(
                name: "IX_BookClubs_BookId",
                table: "BookClubs");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookClubs");

            migrationBuilder.AddColumn<int>(
                name: "BookClubId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookClubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookClubId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookClubId",
                table: "Books",
                column: "BookClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookClubs_BookClubId",
                table: "Books",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id");
        }
    }
}
