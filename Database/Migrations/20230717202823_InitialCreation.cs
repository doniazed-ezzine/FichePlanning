using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filiales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secteur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fonctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAcrif = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkFonction = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Fonctions_FkFonction",
                        column: x => x.FkFonction,
                        principalTable: "Fonctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichePlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkUtilisateur = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkFiliale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Audite = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichePlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichePlannings_Filiales_FkFiliale",
                        column: x => x.FkFiliale,
                        principalTable: "Filiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichePlannings_Utilisateurs_FkUtilisateur",
                        column: x => x.FkUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePlanning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NbrJ = table.Column<int>(type: "int", nullable: false),
                    FkPlanning = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periodes_FichePlannings_FkPlanning",
                        column: x => x.FkPlanning,
                        principalTable: "FichePlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichePlannings_FkFiliale",
                table: "FichePlannings",
                column: "FkFiliale");

            migrationBuilder.CreateIndex(
                name: "IX_FichePlannings_FkUtilisateur",
                table: "FichePlannings",
                column: "FkUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Periodes_FkPlanning",
                table: "Periodes",
                column: "FkPlanning");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_FkFonction",
                table: "Utilisateurs",
                column: "FkFonction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropTable(
                name: "FichePlannings");

            migrationBuilder.DropTable(
                name: "Filiales");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Fonctions");
        }
    }
}
