using ApiVideojuegos.Domain.Entities;

namespace ApiVideojuegos.Domain.Interfaces
{
    public interface IVideojuegoRepository
    {
        Task<List<Videojuego>> GetAllAsync();
        Task<Videojuego?> GetByIdAsync(int id);
        Task AddAsync(Videojuego videojuego);
        void Update(Videojuego videojuego);
        void Delete(Videojuego videojuego);
        Task<bool> ExistsByNameAsync(string nombre);
        Task SaveChangesAsync();
    }
}