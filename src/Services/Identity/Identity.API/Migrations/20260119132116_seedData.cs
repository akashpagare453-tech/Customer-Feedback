using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.API.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d67569-22a9-4c42-992c-29e7689fd9bf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "951839d9-1e63-489d-86c3-2f6f1fa4918e", "0761b72b-fde8-4d30-a7fd-6d0b918eeff0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89667700-f00b-4ef9-a29d-dd17aa4ca729", "6a52ab60-397f-4998-99c1-800f40b084d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89667700-f00b-4ef9-a29d-dd17aa4ca729");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951839d9-1e63-489d-86c3-2f6f1fa4918e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0761b72b-fde8-4d30-a7fd-6d0b918eeff0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a52ab60-397f-4998-99c1-800f40b084d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b038b7a-a4be-4a7c-9884-dfb866f924aa", null, "Customer", "CUSTOMER" },
                    { "56265537-10e7-4812-a91b-ef0e6468ce90", null, "Admin", "ADMIN" },
                    { "85fc9708-e8b7-4de2-9b5c-964b64a5dd02", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6338d49a-b6b7-4b16-9327-abc9fc1062e4", 0, "3a413c4c-1ab4-48dd-8542-8f7fa67eb08e", "manager@example.com", true, false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPhu+tdeRuw0fAehYNncEvkGpxcvmjUJUpyx5Opp6u8hWdpZbtVrPdV6g3s0AQNiSQ==", null, false, "ae1cf664-c77c-439d-b169-d6e5c356677d", false, "manager@example.com" },
                    { "aa7efc30-550f-46d9-a5b3-6f4697cb6aac", 0, "0d8f49d2-696b-4e9f-83c6-541495d3e139", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEE8RP772TQnOW7fqujGKimoGGynzwMkLxvIrw9aRHVS1mE6W5UrbjrkY2oi0ZGJPjw==", null, false, "c72a7fab-80ed-4894-8da7-4a5826b07f17", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "85fc9708-e8b7-4de2-9b5c-964b64a5dd02", "6338d49a-b6b7-4b16-9327-abc9fc1062e4" },
                    { "56265537-10e7-4812-a91b-ef0e6468ce90", "aa7efc30-550f-46d9-a5b3-6f4697cb6aac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b038b7a-a4be-4a7c-9884-dfb866f924aa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "85fc9708-e8b7-4de2-9b5c-964b64a5dd02", "6338d49a-b6b7-4b16-9327-abc9fc1062e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56265537-10e7-4812-a91b-ef0e6468ce90", "aa7efc30-550f-46d9-a5b3-6f4697cb6aac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56265537-10e7-4812-a91b-ef0e6468ce90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85fc9708-e8b7-4de2-9b5c-964b64a5dd02");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6338d49a-b6b7-4b16-9327-abc9fc1062e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa7efc30-550f-46d9-a5b3-6f4697cb6aac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04d67569-22a9-4c42-992c-29e7689fd9bf", null, "Customer", "CUSTOMER" },
                    { "89667700-f00b-4ef9-a29d-dd17aa4ca729", null, "Admin", "ADMIN" },
                    { "951839d9-1e63-489d-86c3-2f6f1fa4918e", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0761b72b-fde8-4d30-a7fd-6d0b918eeff0", 0, "12271808-d514-4090-b705-30cd82bb2427", "manager@example.com", true, false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMLcxoCBCw3b3zLIH8Ba3RwI3Cc7o/EVsgD8DWOKALTDSw9+TqyjTJCJH6RNt0gGxg==", null, false, "cbee2179-02c9-43bb-bbee-4b611f326bec", false, "manager@example.com" },
                    { "6a52ab60-397f-4998-99c1-800f40b084d5", 0, "ec04cf87-71fb-4b04-ae74-50515d174999", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIEGnzacI1AxoNpzaS02Z+Oqvu6qvxMRlo48oRbZx473PpyraCmJID+1MqxEOwxpaQ==", null, false, "59a529c8-5cc3-470b-9da8-63cfaff81623", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "951839d9-1e63-489d-86c3-2f6f1fa4918e", "0761b72b-fde8-4d30-a7fd-6d0b918eeff0" },
                    { "89667700-f00b-4ef9-a29d-dd17aa4ca729", "6a52ab60-397f-4998-99c1-800f40b084d5" }
                });
        }
    }
}
