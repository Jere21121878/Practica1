using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fc416a5-828d-47b2-9b0d-48b0860465bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b2bc01-c17f-4079-b63d-46e3bcda86c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3657ead6-9973-4e38-a302-5d6ef2497764", "fdbafa0b-a9a4-491d-9f7b-45b1e3562bc4", "Comprador", "COMPRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6f04955-4de7-443e-8845-230c5402ea11", "c4bfdbe1-29b9-49d6-86b1-809609f21753", "Vendedor", "VENDEDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3657ead6-9973-4e38-a302-5d6ef2497764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6f04955-4de7-443e-8845-230c5402ea11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fc416a5-828d-47b2-9b0d-48b0860465bc", "6163ac93-22e5-4966-ba25-828772477ec6", "Vendedor", "VENDEDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3b2bc01-c17f-4079-b63d-46e3bcda86c0", "dad21fec-3885-4c4b-94d6-fa5eeec71a1c", "Comprador", "COMPRADOR" });
        }
    }
}
