using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _902 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Locals_LocalId1",
                table: "Fotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Productos_ProductoId1",
                table: "Fotos");

            migrationBuilder.DropIndex(
                name: "IX_Fotos_LocalId1",
                table: "Fotos");

            migrationBuilder.DropIndex(
                name: "IX_Fotos_ProductoId1",
                table: "Fotos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399bd5dd-43f2-4f18-8e02-a6f72e0211fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9715aca-8624-49fd-b7f0-9663708cc1d1");

            migrationBuilder.DropColumn(
                name: "LocalId1",
                table: "Fotos");

            migrationBuilder.DropColumn(
                name: "ProductoId1",
                table: "Fotos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10353f84-6cfb-4bba-a9be-8d321b62e650", "45408d11-4087-4310-b149-40ce66bf1df7", "Vendedor", "VENDEDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "385527a3-cc5d-44b1-b7a2-3ed5bfea40e5", "0c4f887e-8bd4-4b3b-8fcd-756467098cb6", "Comprador", "COMPRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10353f84-6cfb-4bba-a9be-8d321b62e650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "385527a3-cc5d-44b1-b7a2-3ed5bfea40e5");

            migrationBuilder.AddColumn<int>(
                name: "LocalId1",
                table: "Fotos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId1",
                table: "Fotos",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "399bd5dd-43f2-4f18-8e02-a6f72e0211fa", "d2cd8da3-5809-4882-8753-72fe87f41215", "Vendedor", "VENDEDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9715aca-8624-49fd-b7f0-9663708cc1d1", "1f247f2a-f697-48c9-886f-4488779b3514", "Comprador", "COMPRADOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_LocalId1",
                table: "Fotos",
                column: "LocalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_ProductoId1",
                table: "Fotos",
                column: "ProductoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Locals_LocalId1",
                table: "Fotos",
                column: "LocalId1",
                principalTable: "Locals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Productos_ProductoId1",
                table: "Fotos",
                column: "ProductoId1",
                principalTable: "Productos",
                principalColumn: "Id");
        }
    }
}
