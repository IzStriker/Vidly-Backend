using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class addAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "AccountTypeId",
                table: "CustomersDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomersDetails_AccountTypeId",
                table: "CustomersDetails",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersDetails_AccountTypes_AccountTypeId",
                table: "CustomersDetails",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersDetails_AccountTypes_AccountTypeId",
                table: "CustomersDetails");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_CustomersDetails_AccountTypeId",
                table: "CustomersDetails");

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

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "CustomersDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a5705d1-2798-4c35-8ae7-4bdfb0d4fd60", "56e027c5-dc18-43c8-b368-d005f1c951be", "Admin", "ADMIN" },
                    { "355c6d2e-c51e-459c-bb5d-b6df5ddf01b3", "a3ded29b-a502-4d18-8766-eb11414a1f86", "Customer", "CUSTOMER" },
                    { "704a6e21-46df-4206-ace5-8955e4ee30d4", "b0e36d9a-177f-4c5b-a296-5a87c11a100e", "Staff", "STAFF" }
                });
        }
    }
}
