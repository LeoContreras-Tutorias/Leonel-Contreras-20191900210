using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;
using ApiVideojuegos.Domain.Services;

namespace ApiVideojuegos.Application.Services
{
    public class CategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly CategoriaDomainService _categoriaDomainService;

        public CategoriaAppService(
            ICategoriaRepository categoriaRepository,
            CategoriaDomainService categoriaDomainService)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaDomainService = categoriaDomainService;
        }

        public async Task<List<Categoria>> ObtenerTodasAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<(bool Exito, string Mensaje)> AgregarAsync(Categoria categoria)
        {
            var validacion = await _categoriaDomainService.ValidarNuevaCategoriaAsync(categoria);
            if (!validacion.EsValido)
                return (false, validacion.Mensaje);

            await _categoriaRepository.AddAsync(categoria);
            await _categoriaRepository.SaveChangesAsync();

            return (true, "Categoría agregada correctamente.");
        }
    }
}