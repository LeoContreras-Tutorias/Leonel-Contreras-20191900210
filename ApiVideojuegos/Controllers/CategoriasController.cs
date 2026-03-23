using ApiVideojuegos.Application.Services;
using ApiVideojuegos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiVideojuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaAppService _categoriaAppService;

        public CategoriasController(CategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            var categorias = await _categoriaAppService.ObtenerTodasAsync();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            var resultado = await _categoriaAppService.AgregarAsync(categoria);

            if (!resultado.Exito)
                return BadRequest(new { mensaje = resultado.Mensaje });

            return Ok(new { mensaje = resultado.Mensaje });
        }
    }
}