using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaPet.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    AlertaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.AlertaId);
                });

            migrationBuilder.CreateTable(
                name: "Alimentacoes",
                columns: table => new
                {
                    AlimentacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAlimentacao = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentacoes", x => x.AlimentacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoUnico = table.Column<int>(type: "int", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVacina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAplicacao = table.Column<int>(type: "int", nullable: false),
                    Validade = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.VacinaId);
                    table.ForeignKey(
                        name: "FK_Vacinas_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    TagId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Tags_TagId1",
                        column: x => x.TagId1,
                        principalTable: "Tags",
                        principalColumn: "TagId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentacoes_PetId",
                table: "Alimentacoes",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UsuarioId",
                table: "Pets",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PetId",
                table: "Tags",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TagId1",
                table: "Usuarios",
                column: "TagId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas_PetId",
                table: "Vacinas",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentacoes_Pets_PetId",
                table: "Alimentacoes",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Usuarios_UsuarioId",
                table: "Pets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Pets_PetId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Alimentacoes");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
