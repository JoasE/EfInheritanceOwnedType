using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfInheritanceOwnedType.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.CreateTable(
    name: "SubTypeOnes",
    columns: table => new
    {
        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_SubTypeOnes", x => x.Id);
    });

migrationBuilder.CreateTable(
    name: "SubTypeTwos",
    columns: table => new
    {
        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_SubTypeTwos", x => x.Id);
    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTypeOnes");

            migrationBuilder.DropTable(
                name: "SubTypeTwos");
        }
    }
}
