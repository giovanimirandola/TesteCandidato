using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteCandidatoWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "char(9)", maxLength: 9, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UF = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    Unidade = table.Column<long>(type: "bigint", nullable: true),
                    IBGE = table.Column<int>(type: "int", nullable: true),
                    GIA = table.Column<long>(type: "bigint", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEPs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEPs");
        }
    }
}
