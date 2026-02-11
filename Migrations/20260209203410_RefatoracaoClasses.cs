using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExemploWebAPI3.Migrations
{
    /// <inheritdoc />
    public partial class RefatoracaoClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_filmeId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Salas_salaId",
                table: "Sessoes");

            migrationBuilder.RenameColumn(
                name: "salaId",
                table: "Sessoes",
                newName: "SalaId");

            migrationBuilder.RenameColumn(
                name: "filmeId",
                table: "Sessoes",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_salaId",
                table: "Sessoes",
                newName: "IX_Sessoes_SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_filmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeId");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Salas_SalaId",
                table: "Sessoes",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Salas_SalaId",
                table: "Sessoes");

            migrationBuilder.RenameColumn(
                name: "SalaId",
                table: "Sessoes",
                newName: "salaId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "Sessoes",
                newName: "filmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_SalaId",
                table: "Sessoes",
                newName: "IX_Sessoes_salaId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_filmeId");

            migrationBuilder.AlterColumn<int>(
                name: "salaId",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "filmeId",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_filmeId",
                table: "Sessoes",
                column: "filmeId",
                principalTable: "Filmes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Salas_salaId",
                table: "Sessoes",
                column: "salaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }
    }
}
