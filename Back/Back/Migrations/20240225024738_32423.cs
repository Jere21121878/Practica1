using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _32423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2584e82d-ce85-4318-bf87-32c676057c94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac78e6a-b444-4cf5-8477-e03b9dc9e225");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33e01c1f-d485-440c-b294-c4b47a8cc4bd", "242e7910-009a-4554-b06f-6224ab845e16", "Vendedor", "VENDEDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5900b7c6-396c-4ce4-8209-d2b4796df3c2", "d2da7d2f-d964-4619-b7ab-083263c2e85d", "Comprador", "COMPRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2584e82d-ce85-4318-bf87-32c676057c94", "cfd4c420-802c-4e4a-9718-1e436e978228", "Comprador", "COMPRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ac78e6a-b444-4cf5-8477-e03b9dc9e225", "30d4652c-debe-435e-9344-e83cb816453c", "Vendedor", "VENDEDOR" });
        }
    }
}
