using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExemploWebAPI3.Migrations
{
    /// <inheritdoc />
    public partial class SessaoComFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Sessoes_sessaoId",
                table: "Sessoes");

            migrationBuilder.RenameColumn(
                name: "sessaoId",
                table: "Sessoes",
                newName: "salaId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_sessaoId",
                table: "Sessoes",
                newName: "IX_Sessoes_salaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Salas_salaId",
                table: "Sessoes",
                column: "salaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Salas_salaId",
                table: "Sessoes");

            migrationBuilder.RenameColumn(
                name: "salaId",
                table: "Sessoes",
                newName: "sessaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_salaId",
                table: "Sessoes",
                newName: "IX_Sessoes_sessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Sessoes_sessaoId",
                table: "Sessoes",
                column: "sessaoId",
                principalTable: "Sessoes",
                principalColumn: "Id");
        }
    }
}
