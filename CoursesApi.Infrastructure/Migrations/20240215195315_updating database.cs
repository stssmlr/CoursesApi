using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudonym = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Age", "Name", "Pseudonym", "Surname" },
                values: new object[,]
                {
                    { 1, 29, "Bob", "Scott Carol", "Parsons" },
                    { 2, 27, "Carolina", "Kristen Josh", "Lara" },
                    { 3, 36, "Edwin", "Tommy Walker", "Webster" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Courses telling you about Languages.", "Languages Courses" },
                    { 2, "Courses telling you about Sports.", "Sport Courses" },
                    { 3, "Courses telling you about IT and Programming.", "IT Courses" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "FullText", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Learn English Language", "Learn English Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.", "English Courses" },
                    { 2, 2, 1, "Learn German Language", "Learn German Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.", "German Courses" },
                    { 3, 2, 1, "Learn Polish Language", "Learn Polish Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.", "Polish Courses" },
                    { 4, 3, 1, "Learn Chinese Language", "Learn Chinese Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.", "Chinese Courses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Pseudonym",
                table: "Author",
                column: "Pseudonym",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
