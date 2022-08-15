using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class addAccountTypeRequiredAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "87235890-afa2-49a7-a31e-3215b5186692");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "d7ca4074-396b-49ce-b0d5-ae48033a678f");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "d85a1d24-04c1-4455-a15f-15e1898de39d");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "e3fc93f5-68ae-411e-892c-0ff7a9e7eb8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "176c3701-1d1c-4997-9084-f42366afbd99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0af44a6-d3dc-427b-9a14-0088d4ec1883");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5762ea1-f800-4972-8806-ee3c05fabcb3");

            migrationBuilder.AddColumn<int>(
                name: "RequiredAge",
                table: "AccountTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "Name", "RequiredAge" },
                values: new object[,]
                {
                    { "062a37ac-b184-4e33-8a8e-afebd2f7fd1e", "Pay for rentals at the end of each month.", "Monthly", 0 },
                    { "2945e0ad-f15c-4c72-b53b-a6a9c13b2f21", "Pay for each rental before collection.", "Pay As You Go", 18 },
                    { "a6744a88-ae51-44f3-9ecc-8b959badc918", "Pay for rentals every 3 months.", "Quarterly", 0 },
                    { "b3f34eec-3d08-4d21-a411-d4a08639ed09", "Pay for rental at the end of the year.", "Yearly", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23db0290-cf92-446a-91f6-0904ecb2b4ac", "03fdb27f-2bb5-4287-b707-7fcb0b0ce474", "Staff", "STAFF" },
                    { "b17cb731-507d-4818-99be-511126cb087c", "25e23825-d9d5-48c1-ba6c-d5ab296bd3a2", "Customer", "CUSTOMER" },
                    { "b3d89ae4-a25a-4763-a43a-a8b7bd270c17", "b4d5e00a-ba72-4397-a5e5-8a2900d29673", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "062a37ac-b184-4e33-8a8e-afebd2f7fd1e");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "2945e0ad-f15c-4c72-b53b-a6a9c13b2f21");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "a6744a88-ae51-44f3-9ecc-8b959badc918");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: "b3f34eec-3d08-4d21-a411-d4a08639ed09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23db0290-cf92-446a-91f6-0904ecb2b4ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b17cb731-507d-4818-99be-511126cb087c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d89ae4-a25a-4763-a43a-a8b7bd270c17");

            migrationBuilder.DropColumn(
                name: "RequiredAge",
                table: "AccountTypes");

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "87235890-afa2-49a7-a31e-3215b5186692", "Pay for rentals every 3 months.", "Quarterly" },
                    { "d7ca4074-396b-49ce-b0d5-ae48033a678f", "Pay for rentals at the end of each month.", "Monthly" },
                    { "d85a1d24-04c1-4455-a15f-15e1898de39d", "Pay for rental at the end of the year.", "Yearly" },
                    { "e3fc93f5-68ae-411e-892c-0ff7a9e7eb8d", "Pay for each rental before collection.", "Pay As You Go" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "176c3701-1d1c-4997-9084-f42366afbd99", "67fdd856-29e9-490d-979d-21fc49f54fb2", "Admin", "ADMIN" },
                    { "a0af44a6-d3dc-427b-9a14-0088d4ec1883", "8862f4e1-8fc4-45b1-bfbc-0be46be0b67e", "Customer", "CUSTOMER" },
                    { "e5762ea1-f800-4972-8806-ee3c05fabcb3", "3d23085c-db36-4244-860e-c59dfbf367e6", "Staff", "STAFF" }
                });
        }
    }
}
