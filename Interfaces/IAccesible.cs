using Microsoft.AspNetCore.Mvc;
using TODO.Models;
using TODO.Models.Dtos;

namespace TODO.Interfaces
{
    interface IAccesible
    {
        Task<Usuario> Login(LoginDTO modelo);
        Task<Usuario> Registro(RegistroDTO modelo);
    }
}
