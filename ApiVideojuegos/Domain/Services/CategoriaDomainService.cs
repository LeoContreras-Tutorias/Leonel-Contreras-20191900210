using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;

namespace ApiVideojuegos.Domain.Services
{
    public class CategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<(bool EsValido, string Mensaje)> ValidarNuevaCategoriaAsync(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                return (false, "El nombre de la categoría es obligatorio.");

            if (await _categoriaRepository.ExistsByNameAsync(categoria.Nombre))
                return (false, "Ya existe una categoría con ese nombre.");

            return (true, "OK");
        }
    }
}