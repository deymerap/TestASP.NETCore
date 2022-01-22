using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedDate", "Description", "Price", "PublishedDate", "Title" },
                values: new object[] { new Guid("05f8e9f8-890a-404c-83b9-c72c8d2af30b"), new DateTime(2022, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7590), "Curso basico de Java", 20m, new DateTime(2023, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7599), "Curso de Java desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedDate", "Description", "Price", "PublishedDate", "Title" },
                values: new object[] { new Guid("7af779fd-55ac-458e-915c-c547e031e2eb"), new DateTime(2022, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7608), "Curso basico de Net Core", 1000m, new DateTime(2024, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7608), "Curso de Net Core desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedDate", "Description", "Price", "PublishedDate", "Title" },
                values: new object[] { new Guid("e8557c65-fd50-47eb-8b65-f79021440a3a"), new DateTime(2022, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7606), "Curso basico de C#", 56m, new DateTime(2024, 1, 20, 23, 21, 42, 624, DateTimeKind.Local).AddTicks(7606), "Curso de C# desde cero hasta avanzado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
