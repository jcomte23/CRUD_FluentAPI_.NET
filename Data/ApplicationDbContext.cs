using CRUD_FluentAPI_.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_FluentAPI_.NET.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
