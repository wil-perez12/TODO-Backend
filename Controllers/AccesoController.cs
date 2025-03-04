using Microsoft.AspNetCore.Mvc;
using TODO.Helpers;
using TODO.Interfaces;
using TODO.Models.Dtos;
using TODO.Models;


namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class AccesoController : ControllerBase
    {
        private readonly IAccesible _Iacceso;
        private readonly TokenHelper _helpers;

        public AccesoController(IAccesible iacceso, TokenHelper helpers)
        {
            _Iacceso = iacceso;
            _helpers = helpers;
        }


        //endpoint que retorna un jwt si el usuario esta autenticado
        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginDTO modelo)
        {
            var usuarioAutenticado = await _Iacceso.Login(modelo);

            if (usuarioAutenticado == null)
                return Unauthorized(new {mensaje = "Credenciales Incorrectas"});
            else
                return Ok(_helpers.TokenJwt(usuarioAutenticado));
        }


        //endpoint para registrar el usuario en la app
        [HttpPost("Registro")]
        public async Task<IActionResult> Registro(RegistroDTO modelo)
        {

            var registro = await _Iacceso.Registro(modelo);

            if (registro == null)
                return BadRequest(new { mensaje = "El usuario ya existe o hubo un error en el registro" });
            else
                return Ok(new { mensaje = "Usuario registrado correctamente." });
        }

    }
}
