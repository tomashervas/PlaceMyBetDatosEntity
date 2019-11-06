using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBetAPIWeb.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    eventoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    local = table.Column<string>(nullable: true),
                    visitante = table.Column<string>(nullable: true),
                    fechaHoraEvento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.eventoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    apellidos = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false),
                    saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    mercadoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mercado = table.Column<string>(nullable: true),
                    cuotaOver = table.Column<double>(nullable: false),
                    cuotaUnder = table.Column<double>(nullable: false),
                    dineroOver = table.Column<double>(nullable: false),
                    dineroUnder = table.Column<double>(nullable: false),
                    eventoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.mercadoID);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_eventoID",
                        column: x => x.eventoID,
                        principalTable: "Eventos",
                        principalColumn: "eventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    cuentaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    saldo = table.Column<double>(nullable: false),
                    banco = table.Column<string>(nullable: true),
                    tarjeta = table.Column<string>(nullable: true),
                    usuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.cuentaID);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    apuestaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mercado = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    cuota = table.Column<double>(nullable: false),
                    dinero = table.Column<double>(nullable: false),
                    mercadoID = table.Column<int>(nullable: false),
                    usuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.apuestaID);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_mercadoID",
                        column: x => x.mercadoID,
                        principalTable: "Mercados",
                        principalColumn: "mercadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_mercadoID",
                table: "Apuestas",
                column: "mercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_usuarioID",
                table: "Apuestas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_usuarioID",
                table: "Cuentas",
                column: "usuarioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_eventoID",
                table: "Mercados",
                column: "eventoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
