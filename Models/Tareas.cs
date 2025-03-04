namespace TODO.Models
{
  class Tareas
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        //relacion con la tabla usuario
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
