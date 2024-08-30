using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_FluentAPI_.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPesoIntoCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Categorias");
        }
    }
}
