using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CricaoModelCopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Books_BookId",
                table: "BookLendings");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CopyCode",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookLendings",
                newName: "CopyId");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_BookId",
                table: "BookLendings",
                newName: "IX_BookLendings_CopyId");

            migrationBuilder.CreateTable(
                name: "Copies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopyCode = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Copies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookId",
                table: "Copies",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Copies_CopyId",
                table: "BookLendings",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Copies_CopyId",
                table: "BookLendings");

            migrationBuilder.DropTable(
                name: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CopyId",
                table: "BookLendings",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_CopyId",
                table: "BookLendings",
                newName: "IX_BookLendings_BookId");

            migrationBuilder.AddColumn<string>(
                name: "CopyCode",
                table: "Books",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Books_BookId",
                table: "BookLendings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
