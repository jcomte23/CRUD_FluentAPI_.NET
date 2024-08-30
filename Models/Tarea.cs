using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_FluentAPI_.NET.Enums;

namespace CRUD_FluentAPI_.NET.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public required string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public NivelPrioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }

        // conexiones foraneas
        public virtual Categoria Categoria { get; set; }

        // propiedades No Mapeables
        public string? Resumen { get; set; }
    }
}