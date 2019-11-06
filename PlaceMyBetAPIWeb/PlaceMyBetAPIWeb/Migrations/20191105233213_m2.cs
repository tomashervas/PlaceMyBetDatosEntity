using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBetAPIWeb.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "eventoID", "fechaHoraEvento", "local", "visitante" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 6, 0, 32, 12, 657, DateTimeKind.Local).AddTicks(4637), "Valencia", "Madrid" },
                    { 2, new DateTime(2019, 11, 6, 0, 32, 12, 663, DateTimeKind.Local).AddTicks(4491), "Barcelona", "Betis" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuarioID", "apellidos", "edad", "email", "nombre", "saldo" },
                values: new object[,]
                {
                    { 1, "Garcia", 34, "pepegarcia@gmail.com", "Pepe", 200.0 },
                    { 2, "Sanchez", 25, "rosasanchez@gmail.com", "Rosa", 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "cuentaID", "banco", "saldo", "tarjeta", "usuarioID" },
                values: new object[,]
                {
                    { 1, "Bankia", 200.0, "2222222222222222", 1 },
                    { 2, "Savadell", 200.0, "333333333333333", 2 }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "mercadoID", "cuotaOver", "cuotaUnder", "dineroOver", "dineroUnder", "eventoID", "mercado" },
                values: new object[,]
                {
                    { 1, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 1, "1.5" },
                    { 2, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 1, "2.5" }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "apuestaID", "cuota", "dinero", "mercado", "mercadoID", "tipo", "usuarioID" },
                values: new object[] { 1, 1.8999999999999999, 20.0, "1.5", 1, "under", 1 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "apuestaID", "cuota", "dinero", "mercado", "mercadoID", "tipo", "usuarioID" },
                values: new object[] { 2, 1.8999999999999999, 10.0, "1.5", 1, "over", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "apuestaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "apuestaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "cuentaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "cuentaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "eventoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "mercadoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "mercadoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "usuarioID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "usuarioID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "eventoID",
                keyValue: 1);
        }
    }
}
