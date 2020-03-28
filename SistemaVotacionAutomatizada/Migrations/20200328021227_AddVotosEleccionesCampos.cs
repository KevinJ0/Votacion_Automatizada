using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVotacionAutomatizada.Migrations
{
    public partial class AddVotosEleccionesCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "VotosElecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EleccionID = table.Column<int>(nullable: true),
                    CandidatoID = table.Column<int>(nullable: true),
                    CiudadanoID = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    PartidoId = table.Column<int>(nullable: true),
                    PuestoElectivosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotosElecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK__VotosElec__Candi__7F2BE32F",
                        column: x => x.CandidatoID,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__VotosElec__Ciuda__00200768",
                        column: x => x.CiudadanoID,
                        principalTable: "Ciudadanos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__VotosElec__Elecc__7E37BEF6",
                        column: x => x.EleccionID,
                        principalTable: "Elecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotosElecciones_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotosElecciones_Puesto_electivos_PuestoElectivosId",
                        column: x => x.PuestoElectivosId,
                        principalTable: "Puesto_electivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

  

            migrationBuilder.CreateIndex(
                name: "IX_VotosElecciones_CandidatoID",
                table: "VotosElecciones",
                column: "CandidatoID");

            migrationBuilder.CreateIndex(
                name: "IX_VotosElecciones_CiudadanoID",
                table: "VotosElecciones",
                column: "CiudadanoID");

            migrationBuilder.CreateIndex(
                name: "IX_VotosElecciones_EleccionID",
                table: "VotosElecciones",
                column: "EleccionID");

            migrationBuilder.CreateIndex(
                name: "IX_VotosElecciones_PartidoId",
                table: "VotosElecciones",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_VotosElecciones_PuestoElectivosId",
                table: "VotosElecciones",
                column: "PuestoElectivosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Ciudadanos");

            migrationBuilder.DropTable(
                name: "Elecciones");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Puesto_electivos");
        }
    }
}
