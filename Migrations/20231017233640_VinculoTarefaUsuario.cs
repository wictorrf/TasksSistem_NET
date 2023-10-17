using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listTask_Api.Migrations
{
    /// <inheritdoc />
    public partial class VinculoTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_Usuarioid",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Usuario_id",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Usuarioid",
                table: "Tarefas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_Usuarioid",
                table: "Tarefas",
                newName: "IX_Tarefas_UsuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tarefas",
                newName: "Usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                newName: "IX_Tarefas_Usuarioid");

            migrationBuilder.AlterColumn<int>(
                name: "Usuarioid",
                table: "Tarefas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Usuario_id",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_Usuarioid",
                table: "Tarefas",
                column: "Usuarioid",
                principalTable: "Usuarios",
                principalColumn: "id");
        }
    }
}
