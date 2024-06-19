using System.Collections.Generic;


namespace ProyectoUT5
{
    public class Discipline
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public List<Modality>? Modalidades { get; set; }
        public List<Category>? Categorias { get; set; }
    }
}

