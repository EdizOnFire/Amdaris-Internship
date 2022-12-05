using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioEditor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AudioFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AudioFile_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFileId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFile_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioFile_Users_AudioFiles_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "AudioFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioFile_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioFiles_UserId",
                table: "AudioFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile_Users_AudioFileId",
                table: "AudioFile_Users",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFile_Users_UserId",
                table: "AudioFile_Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AudioFiles_Users_UserId",
                table: "AudioFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioFiles_Users_UserId",
                table: "AudioFiles");

            migrationBuilder.DropTable(
                name: "AudioFile_Users");

            migrationBuilder.DropIndex(
                name: "IX_AudioFiles_UserId",
                table: "AudioFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AudioFiles");
        }
    }
}
