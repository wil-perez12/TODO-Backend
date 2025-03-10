using Microsoft.AspNetCore.Mvc;
using TODO.Models;
using TODO.Models.Dtos;

namespace TODO.Interfaces
{
    public interface IAccesible
    {
        Task<Usuario> Login(LoginDTO modelo);
        Task<Usuario> Registro(RegistroDTO modelo);
        Task<List<Usuario>> GetUsuario();
    }
}
