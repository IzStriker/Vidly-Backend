using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class customerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CustomersDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersDetails_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a5705d1-2798-4c35-8ae7-4bdfb0d4fd60", "56e027c5-dc18-43c8-b368-d005f1c951be", "Admin", "ADMIN" },
                    { "355c6d2e-c51e-459c-bb5d-b6df5ddf01b3", "a3ded29b-a502-4d18-8766-eb11414a1f86", "Customer", "CUSTOMER" },
                    { "704a6e21-46df-4206-ace5-8955e4ee30d4", "b0e36d9a-177f-4c5b-a296-5a87c11a100e", "Staff", "STAFF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersDetails_ApplicationUserId",
                table: "CustomersDetails",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a5705d1-2798-4c35-8ae7-4bdfb0d4fd60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355c6d2e-c51e-459c-bb5d-b6df5ddf01b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "704a6e21-46df-4206-ace5-8955e4ee30d4");

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
    }
}
