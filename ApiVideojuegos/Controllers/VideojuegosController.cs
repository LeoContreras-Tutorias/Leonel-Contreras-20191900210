using ApiVideojuegos.Application.Services;
using ApiVideojuegos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiVideojuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideojuegosController : ControllerBase
    {
        private readonly VideojuegoAppService _videojuegoAppService;

        public VideojuegosController(VideojuegoAppService videojuegoAppService)
        {
            _videojuegoAppService = videojuegoAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Videojuego>>> Get()
        {
            var videojuegos = await _videojuegoAppService.ObtenerTodosAsync();
            return Ok(videojuegos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetById(int id)
        {
            var videojuego = await _videojuegoAppService.ObtenerPorIdAsync(id);

            if (videojuego is null)
                return NotFound(new { mensaje = "Videojuego no encontrado." });

            return Ok(videojuego);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Videojuego videojuego)
        {
            var resultado = await _videojuegoAppService.AgregarAsync(videojuego);

            if (!resultado.Exito)
                return BadRequest(new { mensaje = resultado.Mensaje });

            return Ok(new { mensaje = resultado.Mensaje });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Videojuego videojuego)
        {
            var resultado = await _videojuegoAppService.ActualizarAsync(id, videojuego);

            if (!resultado.Exito)
                return BadRequest(new { mensaje = resultado.Mensaje });

            return Ok(new { mensaje = resultado.Mensaje });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _videojuegoAppService.EliminarAsync(id);

            if (!resultado.Exito)
                return NotFound(new { mensaje = resultado.Mensaje });

            return Ok(new { mensaje = resultado.Mensaje });
        }
    }
}