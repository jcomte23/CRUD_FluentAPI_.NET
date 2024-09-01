using CRUD_FluentAPI_.NET.Data;
using CRUD_FluentAPI_.NET.Models;
using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var conectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Endpoint para verificar la conexión con la base de datos
app.MapGet("/check-db", async (ApplicationDbContext dbContext) =>
{
    try
    {
        // Intenta realizar una consulta simple para verificar la conexión
        var canConnect = await dbContext.Database.CanConnectAsync();
        if (canConnect)
        {
            return Results.Ok("La conexión a la base de datos es exitosa.");
        }
        else
        {
            return Results.Problem("La conexión a la base de datos falló.", statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    catch (Exception ex)
    {
        // Manejar excepciones de conexión
        return Results.Problem($"La conexión a la base de datos falló: {ex.Message}", statusCode: StatusCodes.Status500InternalServerError);
    }
});

// Endpoint para inicializar la base de datos
app.MapGet("/initialize-db", async (ApplicationDbContext dbContext) =>
{
    try
    {
        // Crear la base de datos si no existe y aplicar las migraciones
        await dbContext.Database.EnsureCreatedAsync();
        return Results.Ok("La base de datos se ha creado e inicializado correctamente.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"La inicialización de la base de datos falló: {ex.Message}", statusCode: StatusCodes.Status500InternalServerError);
    }
});

app.MapGet("/api/v1/tareas", async (ApplicationDbContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas);
});

app.MapGet("/api/v2/tareas", async (ApplicationDbContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(t => t.Categoria));
});

app.MapPost("/api/v1/tareas", async (ApplicationDbContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Created();
});

app.MapPut("/api/v1/tareas/{id}", async (ApplicationDbContext dbContext, [FromRoute] int id, [FromBody] Tarea tarea) =>
{
    var tareaDb = await dbContext.Tareas.FindAsync(id);
    if (tareaDb == null)
    {
        return Results.NotFound();
    }
    tareaDb.Titulo = tarea.Titulo;
    tareaDb.Descripcion = tarea.Descripcion;
    tareaDb.Prioridad = tarea.Prioridad;
    tareaDb.Estado = tarea.Estado;
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/v1/tareas/{id}", async (ApplicationDbContext dbContext, [FromRoute] int id) =>
{
    var tareaDb = await dbContext.Tareas.FindAsync(id);
    if (tareaDb == null)
    {
        return Results.NotFound();
    }
    dbContext.Tareas.Remove(tareaDb);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
