using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicvillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlimentartablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalles de la villa...", new DateTime(2023, 11, 22, 12, 32, 52, 439, DateTimeKind.Local).AddTicks(1627), new DateTime(2023, 11, 22, 12, 32, 52, 439, DateTimeKind.Local).AddTicks(1614), "", 50.0, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalles de la villa...", new DateTime(2023, 11, 22, 12, 32, 52, 439, DateTimeKind.Local).AddTicks(1631), new DateTime(2023, 11, 22, 12, 32, 52, 439, DateTimeKind.Local).AddTicks(1630), "", 200.0, "Premium vista al mar rojo", 20, 1000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
