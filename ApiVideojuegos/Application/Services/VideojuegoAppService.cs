using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;
using ApiVideojuegos.Domain.Services;

namespace ApiVideojuegos.Application.Services
{
    public class VideojuegoAppService
    {
        private readonly IVideojuegoRepository _videojuegoRepository;
        private readonly VideojuegoDomainService _videojuegoDomainService;

        public VideojuegoAppService(
            IVideojuegoRepository videojuegoRepository,
            VideojuegoDomainService videojuegoDomainService)
        {
            _videojuegoRepository = videojuegoRepository;
            _videojuegoDomainService = videojuegoDomainService;
        }

        public async Task<List<Videojuego>> ObtenerTodosAsync()
        {
            return await _videojuegoRepository.GetAllAsync();
        }

        public async Task<Videojuego?> ObtenerPorIdAsync(int id)
        {
            return await _videojuegoRepository.GetByIdAsync(id);
        }

        public async Task<(bool Exito, string Mensaje)> AgregarAsync(Videojuego videojuego)
        {
            var validacion = await _videojuegoDomainService.ValidarNuevoAsync(videojuego);
            if (!validacion.EsValido)
                return (false, validacion.Mensaje);

            await _videojuegoRepository.AddAsync(videojuego);
            await _videojuegoRepository.SaveChangesAsync();

            return (true, "Videojuego agregado correctamente.");
        }

        public async Task<(bool Exito, string Mensaje)> ActualizarAsync(int id, Videojuego videojuego)
        {
            var existente = await _videojuegoRepository.GetByIdAsync(id);
            if (existente is null)
                return (false, "El videojuego no existe.");

            var validacion = await _videojuegoDomainService.ValidarActualizacionAsync(videojuego);
            if (!validacion.EsValido)
                return (false, validacion.Mensaje);

            existente.Nombre = videojuego.Nombre;
            existente.Descripcion = videojuego.Descripcion;
            existente.CategoriaId = videojuego.CategoriaId;
            existente.Activo = videojuego.Activo;

            _videojuegoRepository.Update(existente);
            await _videojuegoRepository.SaveChangesAsync();

            return (true, "Videojuego actualizado correctamente.");
        }

        public async Task<(bool Exito, string Mensaje)> EliminarAsync(int id)
        {
            var existente = await _videojuegoRepository.GetByIdAsync(id);
            if (existente is null)
                return (false, "El videojuego no existe.");

            _videojuegoRepository.Delete(existente);
            await _videojuegoRepository.SaveChangesAsync();

            return (true, "Videojuego eliminado correctamente.");
        }
    }
}