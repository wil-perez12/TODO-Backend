using TODO.ContextDB;
using TODO.Interfaces;
using TODO.Models;
using TODO.Models.Dtos;
using TODO.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TODO.Services
{
    class AccesoSerivce : IAccesible
    {
        private readonly TodoContext _context;
        private readonly EncriptarHelper _encriptarHelper;

        public AccesoSerivce(TodoContext context, EncriptarHelper encriptarHelper)
        {
            this._context = context;
            this._encriptarHelper = encriptarHelper;
        }

        public async Task<Usuario> Login(LoginDTO modelo)
        {
            var BuscarUsuario = await _context.Usuario
                        .FirstOrDefaultAsync(x => x.Correo == modelo.Correo
                        && x.Contrasena == _encriptarHelper.Encriptar(modelo.Contrasena!));

            return BuscarUsuario;
        }


        public async Task<Usuario?> Registro(RegistroDTO modelo)
        {
            // Verifica si el usuario ya existe en la DB
            var existeUsuario = await _context.Usuario.AnyAsync(x => x.Correo == modelo.Correo);

            if (existeUsuario)
            {
                return null; 
            }

            var user = new Usuario
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Correo = modelo.Correo,
                Contrasena = _encriptarHelper.Encriptar(modelo.Contrasena!)
            };

            try
            {
                await _context.Usuario.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return null;
            }
        }
    }
}
