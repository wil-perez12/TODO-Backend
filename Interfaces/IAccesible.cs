using Microsoft.AspNetCore.Mvc;
using TODO.Models.Dtos;

namespace TODO.Interfaces
{
    public interface IAccesible
    {
        Task Login(RegistroDTO modelo);
        Task Registro(RegistroDTO modelo);
    }
}
