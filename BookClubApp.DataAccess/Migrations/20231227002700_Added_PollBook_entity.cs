using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_PollBook_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Polls_PollId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PollId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "PollBook",
                columns: table => new
                {
                    PollId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollBook", x => new { x.PollId, x.BookId });
                    table.ForeignKey(
                        name: "FK_PollBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollBook_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollBook_BookId",
                table: "PollBook",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollBook");

            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PollId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PollId",
                table: "Books",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Polls_PollId",
                table: "Books",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");
        }
    }
}
