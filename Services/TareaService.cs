using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TODO.ContextDB;
using TODO.Interfaces;
using TODO.Models;
using TODO.Models.Dtos;

namespace TODO.Services
{
    public class TareaService : ITareas
    {
        private readonly TodoContext _context;

        public TareaService(TodoContext context)
        {
            _context = context;
        }

        public async Task DeleteTarea(int id)
        {
            var IdTarea = await _context.Tareas
                              .FindAsync(id);

            _context.Tareas.Remove(IdTarea!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tareas>> GetTarea()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tareas> GetTareaByEstado(string estado)
        {
            var tareaEstado = await _context.Tareas.Where(x => x.Estado == estado)
                                                    .FirstOrDefaultAsync();

            return tareaEstado!;
        }

        public async Task<Tareas> GetTareaById(int id)
        {
            var tarea = await _context.Tareas 
                        .FirstOrDefaultAsync(x => x.Id == id);

            return tarea!;
        }

        public async Task<Tareas> PostTarea(TareaDTO modelo)
        {
            var Tareas = new Tareas
            {
                Titulo = modelo.Titulo,
                Estado = modelo.Estado,
                Descripcion = modelo.Descripcion
            };

            try
            {
                await _context.AddAsync(Tareas);
                await _context.SaveChangesAsync();
                return Tareas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tarea: {ex.Message}");
                return null!;
            }
        }
        public async Task<Tareas> PutTarea(int id, TareaDTO modelo)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);

            if (tareaExistente == null)
                return null!; 

            tareaExistente.Titulo = modelo.Titulo;
            tareaExistente.Descripcion = modelo.Descripcion;
            tareaExistente.Estado = modelo.Estado;

            _context.Tareas.Update(tareaExistente);
            await _context.SaveChangesAsync();

            return tareaExistente;
        }
    }
}
