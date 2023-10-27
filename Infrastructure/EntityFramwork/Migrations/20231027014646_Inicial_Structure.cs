using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramwork.Migrations
{
    /// <inheritdoc />
    public partial class Inicial_Structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    montoTotal = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categoria_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaOrigenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_cuentaDestinoId",
                        column: x => x.cuentaDestinoId,
                        principalTable: "Cuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_cuentaOrigenId",
                        column: x => x.cuentaOrigenId,
                        principalTable: "Cuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencia_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_usuarioId",
                table: "Categoria",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_usuarioId",
                table: "Cuenta",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_categoriaId",
                table: "Movimiento",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_cuentaId",
                table: "Movimiento",
                column: "cuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_cuentaDestinoId",
                table: "Transferencia",
                column: "cuentaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_cuentaOrigenId",
                table: "Transferencia",
                column: "cuentaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_usuarioId",
                table: "Transferencia",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
