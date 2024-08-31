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
        });
    }
}
