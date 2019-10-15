using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebAPI.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),                       
                    Title = table.Column<string>(nullable: true),
                    Aurthor = table.Column<string>(nullable: true),
                    Edition = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    CopyCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Fine = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "IssueBooks",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BookBarCode = table.Column<string>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBooks", x => new { x.StudentId, x.BookId });
                    table.ForeignKey(
                        name: "FK_IssueBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueBooks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnBooks",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BookBarCode = table.Column<string>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBooks", x => new { x.StudentId, x.BookId });
                    table.ForeignKey(
                        name: "FK_ReturnBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnBooks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueBooks_BookId",
                table: "IssueBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnBooks_BookId",
                table: "ReturnBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueBooks");

            migrationBuilder.DropTable(
                name: "ReturnBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
