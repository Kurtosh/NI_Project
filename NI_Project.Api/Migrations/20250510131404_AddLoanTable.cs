using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NI_Project.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    BookId = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<string>(type: "TEXT", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDeadline = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.BookId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
