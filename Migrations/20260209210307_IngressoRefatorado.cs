using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExemploWebAPI3.Migrations
{
    /// <inheritdoc />
    public partial class IngressoRefatorado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Ingressos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos",
                column: "SessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Sessoes_SessaoId",
                table: "Ingressos",
                column: "SessaoId",
                principalTable: "Sessoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Sessoes_SessaoId",
                table: "Ingressos");

            migrationBuilder.DropIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Ingressos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
