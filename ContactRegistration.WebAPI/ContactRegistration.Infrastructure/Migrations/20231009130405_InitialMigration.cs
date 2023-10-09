using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar", maxLength: 100, nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    emailId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    address = table.Column<string>(type: "nvarchar", maxLength: 100, nullable: false),
                    ContactId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.emailId);
                    table.ForeignKey(
                        name: "FK_email_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "contact",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_ContactId",
                table: "email",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "contact");
        }
    }
}
