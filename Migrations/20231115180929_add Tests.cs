using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTest.Migrations
{
    /// <inheritdoc />
    public partial class addTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeRange = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestType = table.Column<int>(type: "int", nullable: false),
                    BodyMeasure = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
