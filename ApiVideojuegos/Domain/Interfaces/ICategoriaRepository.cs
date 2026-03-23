using ApiVideojuegos.Domain.Entities;

namespace ApiVideojuegos.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task AddAsync(Categoria categoria);
        Task<bool> ExistsByNameAsync(string nombre);
        Task SaveChangesAsync();
    }
}