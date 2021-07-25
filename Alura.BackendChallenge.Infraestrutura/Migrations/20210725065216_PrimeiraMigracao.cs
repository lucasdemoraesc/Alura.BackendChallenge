using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.BackendChallenge.Infraestrutura.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VIDEOS",
                columns: table => new
                {
                    VIDID = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    VIDTITULO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    VIDDESCRICAO = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    VIDURL = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    VIDCODIGO = table.Column<decimal>(type: "numeric(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDEOS", x => x.VIDID);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_IDVIDEO",
                table: "VIDEOS",
                column: "VIDID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIDEOS");
        }
    }
}
