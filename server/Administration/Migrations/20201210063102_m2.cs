using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "powers",
                columns: new[] { "id", "ip", "modifiedBy", "orgOid", "powerName", "powerValue" },
                values: new object[,]
                {
                    { 1, null, null, null, "General", 5 },
                    { 2, null, null, null, "Colonel", 4 },
                    { 3, null, null, null, "Major", 3 },
                    { 4, null, null, null, "Captain", 2 },
                    { 5, null, null, null, "Lieutenant", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "powers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "powers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "powers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "powers",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "powers",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
