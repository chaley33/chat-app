using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class apiModelsUserContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { 1L, "james.lebron@gmail.com", "LeBron", "James", "lebronjames23" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { 2L, "airjordan@gmail.com", "Michael", "Jordan", "michaeljordan23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L);
        }
    }
}
