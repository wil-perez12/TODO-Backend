using Microsoft.EntityFrameworkCore;
using TODO.Models;

namespace TODO.ContextDB;

class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> option): base(option) { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Tareas> Tareas { get; set; }
}
