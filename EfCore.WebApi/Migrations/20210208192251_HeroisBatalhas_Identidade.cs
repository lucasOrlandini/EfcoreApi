using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.WebApi.Migrations
{
    public partial class HeroisBatalhas_Identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId1",
                table: "Herois");

            migrationBuilder.DropIndex(
                name: "IX_Herois_BatalhaId1",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId1",
                table: "Herois");

            migrationBuilder.CreateTable(
                name: "HeroiBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroiBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadeSecretas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadeSecretas", x => x.id);
                    table.ForeignKey(
                        name: "FK_IdentidadeSecretas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroiBatalhas_HeroiId",
                table: "HeroiBatalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadeSecretas_HeroiId",
                table: "IdentidadeSecretas",
                column: "HeroiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroiBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadeSecretas");

            migrationBuilder.AddColumn<string>(
                name: "BatalhaId",
                table: "Herois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId1",
                table: "Herois",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Herois_BatalhaId1",
                table: "Herois",
                column: "BatalhaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId1",
                table: "Herois",
                column: "BatalhaId1",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
