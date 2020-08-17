using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EsercizioVivaio.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Cognome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Prezzo = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Mod_pagamento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fiore",
                columns: table => new
                {
                    PiantaID = table.Column<int>(nullable: false),
                    Colore = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiore", x => x.PiantaID);
                    table.ForeignKey(
                        name: "FK_Fiore_Piante_PiantaID",
                        column: x => x.PiantaID,
                        principalTable: "Piante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frutta",
                columns: table => new
                {
                    PiantaID = table.Column<int>(nullable: false),
                    Produttivita = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frutta", x => x.PiantaID);
                    table.ForeignKey(
                        name: "FK_Frutta_Piante_PiantaID",
                        column: x => x.PiantaID,
                        principalTable: "Piante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Giardino",
                columns: table => new
                {
                    PiantaID = table.Column<int>(nullable: false),
                    Stagione = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giardino", x => x.PiantaID);
                    table.ForeignKey(
                        name: "FK_Giardino_Piante_PiantaID",
                        column: x => x.PiantaID,
                        principalTable: "Piante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dettaglio_Ordine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantita = table.Column<int>(nullable: false),
                    PiantaID = table.Column<int>(nullable: false),
                    OrdineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dettaglio_Ordine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dettaglio_Ordine_Ordini_OrdineID",
                        column: x => x.OrdineID,
                        principalTable: "Ordini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dettaglio_Ordine_Piante_PiantaID",
                        column: x => x.PiantaID,
                        principalTable: "Piante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dettaglio_Ordine_OrdineID",
                table: "Dettaglio_Ordine",
                column: "OrdineID");

            migrationBuilder.CreateIndex(
                name: "IX_Dettaglio_Ordine_PiantaID",
                table: "Dettaglio_Ordine",
                column: "PiantaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_ClienteId",
                table: "Ordini",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dettaglio_Ordine");

            migrationBuilder.DropTable(
                name: "Fiore");

            migrationBuilder.DropTable(
                name: "Frutta");

            migrationBuilder.DropTable(
                name: "Giardino");

            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Piante");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
