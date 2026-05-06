using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    AnoLancamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NotaImdb = table.Column<decimal>(type: "DECIMAL(3,1)", precision: 3, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Usuario = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Comentario = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Nota = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FilmeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FilmeId",
                table: "Avaliacoes",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
