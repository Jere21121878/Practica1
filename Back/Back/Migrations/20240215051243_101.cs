using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3657ead6-9973-4e38-a302-5d6ef2497764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6f04955-4de7-443e-8845-230c5402ea11");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Productos",
                newName: "Pregunta");

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LocalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalId1 = table.Column<int>(type: "int", nullable: true),
                    ProductoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Locals_LocalId1",
                        column: x => x.LocalId1,
                        principalTable: "Locals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fotos_Productos_ProductoId1",
                        column: x => x.ProductoId1,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399bd5dd-43f2-4f18-8e02-a6f72e0211fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9715aca-8624-49fd-b7f0-9663708cc1d1");

            migrationBuilder.RenameColumn(
                name: "Pregunta",
                table: "Productos",
                newName: "Imagen");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3657ead6-9973-4e38-a302-5d6ef2497764", "fdbafa0b-a9a4-491d-9f7b-45b1e3562bc4", "Comprador", "COMPRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6f04955-4de7-443e-8845-230c5402ea11", "c4bfdbe1-29b9-49d6-86b1-809609f21753", "Vendedor", "VENDEDOR" });
        }
    }
}
