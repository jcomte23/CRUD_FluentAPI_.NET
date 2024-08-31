using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_FluentAPI_.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categorias_CategoriaId",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea");

            migrationBuilder.RenameTable(
                name: "Tarea",
                newName: "Tareas");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tareas",
                newName: "IX_Tareas_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { 1, "Tenetur omnis asperiores voluptas sint.", "Jewelery", 0 },
                    { 2, "Est id ut tenetur unde.", "Health", 0 },
                    { 3, "Ut quis nesciunt eaque eum.", "Automotive", 0 },
                    { 4, "Sed libero repudiandae repudiandae labore.", "Garden", 0 },
                    { 5, "Libero nam molestiae dicta tenetur.", "Garden", 0 }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "Estado", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { 1, 3, "Nam voluptatibus sint nam aut voluptatem quidem earum enim sunt. Sunt ea occaecati ut sequi dolor. Eveniet natus temporibus rerum cum voluptatem corrupti assumenda aliquam quia. Totam autem molestias doloremque id sit laboriosam quasi iste quos. Maxime exercitationem aliquam. Et consequatur aut doloremque voluptate eum dolor aut eos et.", false, new DateTime(2024, 5, 8, 4, 54, 10, 917, DateTimeKind.Local).AddTicks(3852), 3, "Inventore voluptatem culpa." },
                    { 2, 5, "Odio non quas ea mollitia consectetur odit voluptas eveniet nesciunt. Repellat vitae sunt quos soluta quas aliquam corrupti. Aut est earum totam officia consectetur aperiam et atque commodi.", true, new DateTime(2023, 10, 20, 9, 31, 18, 308, DateTimeKind.Local).AddTicks(3739), 3, "Ab quidem et." },
                    { 3, 5, "Suscipit ab eaque nobis consequuntur explicabo aut aut est. Sint dolor sunt est doloribus. Accusamus eum qui architecto.", true, new DateTime(2024, 3, 21, 17, 56, 38, 814, DateTimeKind.Local).AddTicks(3823), 1, "Deserunt blanditiis exercitationem." },
                    { 4, 3, "Laudantium veniam pariatur ut eum animi. Et voluptatem autem quia eos ut iure dolorum. Itaque quia aperiam.", false, new DateTime(2023, 11, 14, 7, 30, 10, 424, DateTimeKind.Local).AddTicks(5558), 0, "Provident sapiente porro." },
                    { 5, 2, "Aut quis et ut rerum reprehenderit aut. Saepe expedita enim provident cupiditate voluptatibus enim rerum aut est. Vero natus accusamus porro esse reprehenderit aperiam totam maiores.", true, new DateTime(2024, 7, 27, 14, 13, 9, 604, DateTimeKind.Local).AddTicks(8008), 1, "Mollitia eligendi eveniet." },
                    { 6, 3, "Quibusdam facere nam aut esse sunt explicabo. Aliquid quia fugit ut recusandae animi. Corrupti facere magni eum pariatur aut mollitia maxime fugiat et. Cumque cumque eaque aperiam. Ipsam velit ut et et.", false, new DateTime(2023, 10, 31, 20, 59, 46, 395, DateTimeKind.Local).AddTicks(7657), 0, "Quasi aut sint." },
                    { 7, 5, "Autem odit consequatur est distinctio architecto et accusamus. Possimus placeat voluptas aut ipsum. Ipsam rerum et rem ratione vero culpa consequatur commodi ipsa.", true, new DateTime(2023, 12, 17, 20, 18, 1, 827, DateTimeKind.Local).AddTicks(8249), 2, "Amet dolor qui." },
                    { 8, 3, "Sunt maiores est explicabo. Itaque autem sequi ipsam facere quo iusto tenetur est. Nihil perspiciatis voluptatem officia ducimus placeat culpa accusamus. Voluptatibus qui atque eveniet saepe. Ab rerum nulla quia.", false, new DateTime(2024, 4, 1, 16, 53, 47, 425, DateTimeKind.Local).AddTicks(7191), 1, "Omnis ratione qui." },
                    { 9, 1, "Id maxime nam eos sit. Voluptatem eveniet ratione delectus necessitatibus placeat quis nam. Quidem ut eos tempore est quia ipsam. Sapiente dolores et est quidem quis facilis est. Omnis molestias sint cupiditate enim minima et similique provident fugit.", true, new DateTime(2024, 5, 30, 6, 35, 25, 745, DateTimeKind.Local).AddTicks(3639), 0, "Vero nihil et." },
                    { 10, 2, "Mollitia omnis dolores. Qui ut expedita voluptatum nobis reiciendis quaerat ullam officiis. Accusamus facere eos et eveniet ipsa. Ut illo non sunt tenetur deleniti molestias aspernatur.", true, new DateTime(2024, 4, 23, 14, 10, 41, 107, DateTimeKind.Local).AddTicks(1746), 0, "Accusamus commodi aut." }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Categorias_CategoriaId",
                table: "Tareas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Categorias_CategoriaId",
                table: "Tareas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Tareas",
                newName: "Tarea");

            migrationBuilder.RenameIndex(
                name: "IX_Tareas_CategoriaId",
                table: "Tarea",
                newName: "IX_Tarea_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categorias_CategoriaId",
                table: "Tarea",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
