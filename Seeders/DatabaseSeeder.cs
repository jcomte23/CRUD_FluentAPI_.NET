using Bogus;
using CRUD_FluentAPI_.NET.Enums;
using CRUD_FluentAPI_.NET.Models;

namespace CRUD_FluentAPI_.NET.Seeders;
public static class DatabaseSeeder
{
    public static List<Categoria> GenerateCategorias(int count)
    {
        var faker = new Faker<Categoria>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)  // IDs secuenciales
            .RuleFor(c => c.Nombre, f => f.Commerce.Categories(1)[0])  // Nombres de categorías
            .RuleFor(c => c.Descripcion, f => f.Lorem.Sentence(5));  // Descripciones

        return faker.Generate(count);
    }

    public static List<Tarea> GenerateTareas(int count, List<Categoria> categorias)
    {
        var faker = new Faker<Tarea>()
            .RuleFor(t => t.Id, f => f.IndexFaker + 1)  // IDs secuenciales
            .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(3))  // Títulos de tareas
            .RuleFor(t => t.Descripcion, f => f.Lorem.Paragraph())  // Descripciones de tareas
            .RuleFor(t => t.Estado, f => f.Random.Bool())   // Estados aleatorios
            .RuleFor(t => t.Prioridad, f => f.PickRandom<NivelPrioridad>())  // Prioridades aleatorias
            .RuleFor(t => t.FechaCreacion, f => f.Date.Past())  // Fechas pasadas
            .RuleFor(t => t.CategoriaId, f => f.PickRandom(categorias).Id);  // Categorías aleatorias

        return faker.Generate(count);
    }

}
