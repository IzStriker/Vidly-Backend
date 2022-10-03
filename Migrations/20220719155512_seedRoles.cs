using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e6aaa5c-4039-4ce7-b461-18e98a6b3924", "b3dd2246-111e-4a9e-a3b9-e96d59273b1f", "Customer", "CUSTOMER" },
                    { "8191fc58-ede9-4e14-b4ab-4f1e23453c63", "4c423f2c-ffde-4808-a16f-dc5abaa5f894", "Staff", "STAFF" },
                    { "864296f3-0770-4225-bf30-d9b8e48c7972", "468528b1-b66e-4f89-a625-ad4364b77aa8", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e6aaa5c-4039-4ce7-b461-18e98a6b3924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8191fc58-ede9-4e14-b4ab-4f1e23453c63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "864296f3-0770-4225-bf30-d9b8e48c7972");
        }
    }
}
