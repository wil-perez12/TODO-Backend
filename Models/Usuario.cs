using System.Threading;

namespace TODO.Models
{
    class Usuario
    {
        public int id { get; set;}
        public string? Nombre { get; set;}
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }

        //Lista de tareas para evitar referencias nulas
        public ICollection<Tareas> Tareas { get; set; }

        public Usuario()
        {
            Tareas = new List<Tareas>();
        }
    }
}
