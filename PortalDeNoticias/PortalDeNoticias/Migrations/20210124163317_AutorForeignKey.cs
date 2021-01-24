using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalDeNoticias.Migrations
{
    public partial class AutorForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticia_Autor_AutorId",
                table: "Noticia");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Noticia",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticia_Autor_AutorId",
                table: "Noticia",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticia_Autor_AutorId",
                table: "Noticia");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Noticia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Noticia_Autor_AutorId",
                table: "Noticia",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
