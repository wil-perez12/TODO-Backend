using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO.Interfaces;
using TODO.Services;

namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareas _servicio;

        public TareasController(ITareas servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListaTareas")]
        public async Task<IActionResult> GetTareas()
        {
            var lista = await _servicio.GetTarea();
            return Ok(lista);
        }

        [HttpGet("TareasPor/{id}")]
        public async Task<IActionResult> GetTareaById(int id)
        {
            var lista = await _servicio.GetTareaById(id);

            if (lista != null)
               return Ok(lista);

            else
            return BadRequest("Tarea no encontrada con este ID");
        }

        [HttpGet("TareasBy/{estado}")]
        public async Task<IActionResult> GetTareaById(string estado)
        {
            var lista = await _servicio.GetTareaByEstado(estado);

            if (lista != null)
                return Ok(lista);

            else
                return BadRequest("Tarea no encontrada con este estado");
        }
    }
}
