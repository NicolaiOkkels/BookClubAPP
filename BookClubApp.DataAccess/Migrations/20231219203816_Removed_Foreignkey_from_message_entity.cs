using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Foreignkey_from_message_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BookClubs_BookClubId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BookClubId",
                table: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages_BookClubId",
                table: "Messages",
                column: "BookClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BookClubs_BookClubId",
                table: "Messages",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
