using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;

namespace ApiVideojuegos.Domain.Services
{
    public class VideojuegoDomainService
    {
        private readonly IVideojuegoRepository _videojuegoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public VideojuegoDomainService(
            IVideojuegoRepository videojuegoRepository,
            ICategoriaRepository categoriaRepository)
        {
            _videojuegoRepository = videojuegoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<(bool EsValido, string Mensaje)> ValidarNuevoAsync(Videojuego videojuego)
        {
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
                return (false, "El nombre del videojuego es obligatorio.");

            if (string.IsNullOrWhiteSpace(videojuego.Descripcion))
                return (false, "La descripción es obligatoria.");

            if (await _videojuegoRepository.ExistsByNameAsync(videojuego.Nombre))
                return (false, "Ya existe un videojuego con ese nombre.");

            var categoria = await _categoriaRepository.GetByIdAsync(videojuego.CategoriaId);
            if (categoria is null)
                return (false, "La categoría no existe.");

            return (true, "OK");
        }

        public async Task<(bool EsValido, string Mensaje)> ValidarActualizacionAsync(Videojuego videojuego)
        {
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
                return (false, "El nombre del videojuego es obligatorio.");

            if (string.IsNullOrWhiteSpace(videojuego.Descripcion))
                return (false, "La descripción es obligatoria.");

            var categoria = await _categoriaRepository.GetByIdAsync(videojuego.CategoriaId);
            if (categoria is null)
                return (false, "La categoría no existe.");

            return (true, "OK");
        }
    }
}