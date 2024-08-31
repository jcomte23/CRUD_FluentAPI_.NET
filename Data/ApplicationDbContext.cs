using Bogus;
using CRUD_FluentAPI_.NET.Enums;
using CRUD_FluentAPI_.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_FluentAPI_.NET.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categorias");
            categoria.HasKey(c => c.Id);
            categoria.Property(c => c.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            categoria.Property(c => c.Descripcion).HasMaxLength(300);

            // Generar datos semillas para Categorias
            var categoriasSeed = GenerateCategorias(5);  // Generar 5 categorías
            categoria.HasData(categoriasSeed);
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tareas");
            tarea.HasKey(t => t.Id);
            tarea.HasOne(t => t.Categoria)
                .WithMany(t => t.Tareas)
                .HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo)
                .HasMaxLength(200)
                .IsRequired();
            tarea.Property(t => t.Descripcion).HasMaxLength(500);
            tarea.Property(t => t.Estado);
            tarea.Property(t => t.Prioridad);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);

            // Generar datos semillas para Tareas
            var categoriasSeed = GenerateCategorias(5);  // Asegúrate de generar las mismas categorías
            var tareasSeed = GenerateTareas(10, categoriasSeed);  // Generar 10 tareas
            tarea.HasData(tareasSeed);
        });
    }


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
