using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVotacionAutomatizada.Migrations
{
    public partial class addDeleteBehaviorCascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Candidato__Parti__70DDC3D8",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK__Candidato__Puest__71D1E811",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Candi__7F2BE32F",
                table: "VotosElecciones");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Ciuda__00200768",
                table: "VotosElecciones");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Elecc__7E37BEF6",
                table: "VotosElecciones");

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Puesto_electivos",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Partidos",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Elecciones",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Ciudadanos",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "Candidatos",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Candidatos",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Candidato__Parti__70DDC3D8",
                table: "Candidatos",
                column: "PartidoID",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Candidato__Puest__71D1E811",
                table: "Candidatos",
                column: "Puesto_electivosID",
                principalTable: "Puesto_electivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Candi__7F2BE32F",
                table: "VotosElecciones",
                column: "CandidatoID",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Ciuda__00200768",
                table: "VotosElecciones",
                column: "CiudadanoID",
                principalTable: "Ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Elecc__7E37BEF6",
                table: "VotosElecciones",
                column: "EleccionID",
                principalTable: "Elecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Candidato__Parti__70DDC3D8",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK__Candidato__Puest__71D1E811",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Candi__7F2BE32F",
                table: "VotosElecciones");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Ciuda__00200768",
                table: "VotosElecciones");

            migrationBuilder.DropForeignKey(
                name: "FK__VotosElec__Elecc__7E37BEF6",
                table: "VotosElecciones");

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Puesto_electivos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Partidos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Elecciones",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Ciudadanos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "Candidatos",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Candidatos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK__Candidato__Parti__70DDC3D8",
                table: "Candidatos",
                column: "PartidoID",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Candidato__Puest__71D1E811",
                table: "Candidatos",
                column: "Puesto_electivosID",
                principalTable: "Puesto_electivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Candi__7F2BE32F",
                table: "VotosElecciones",
                column: "CandidatoID",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Ciuda__00200768",
                table: "VotosElecciones",
                column: "CiudadanoID",
                principalTable: "Ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__VotosElec__Elecc__7E37BEF6",
                table: "VotosElecciones",
                column: "EleccionID",
                principalTable: "Elecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
