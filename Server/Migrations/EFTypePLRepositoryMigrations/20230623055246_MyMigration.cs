using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.Server.Migrations.EFTypePLRepositoryMigrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePLs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePLs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PLs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    TypeLanguageId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLs_TypePLs_TypeLanguageId",
                        column: x => x.TypeLanguageId,
                        principalTable: "TypePLs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLs_TypeLanguageId",
                table: "PLs",
                column: "TypeLanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLs");

            migrationBuilder.DropTable(
                name: "TypePLs");
        }
    }
}
