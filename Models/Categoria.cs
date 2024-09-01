using System.Text.Json.Serialization;

namespace CRUD_FluentAPI_.NET.Models;
public class Categoria
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Peso { get; set; }
    
    // conexiones foraneas
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }

}
