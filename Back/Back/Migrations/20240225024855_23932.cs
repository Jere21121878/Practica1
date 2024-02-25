using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _23932 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e01c1f-d485-440c-b294-c4b47a8cc4bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5900b7c6-396c-4ce4-8209-d2b4796df3c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62c223d0-b4f8-4cc5-bf0e-4dba7108f01d", "4bdfc8be-0b19-49d4-ae7a-ad7b959acbdf", "Comprador", "COMPRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97a30f3d-0654-40b4-822e-07e3ed290fd0", "ed3287b4-0989-4503-8588-b05357dc4956", "Vendedor", "VENDEDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62c223d0-b4f8-4cc5-bf0e-4dba7108f01d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97a30f3d-0654-40b4-822e-07e3ed290fd0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33e01c1f-d485-440c-b294-c4b47a8cc4bd", "242e7910-009a-4554-b06f-6224ab845e16", "Vendedor", "VENDEDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5900b7c6-396c-4ce4-8209-d2b4796df3c2", "d2da7d2f-d964-4619-b7ab-083263c2e85d", "Comprador", "COMPRADOR" });
        }
    }
}
