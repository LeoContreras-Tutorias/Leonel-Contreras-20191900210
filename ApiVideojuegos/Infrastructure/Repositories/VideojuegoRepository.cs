using ApiVideojuegos.Data;
using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVideojuegos.Infrastructure.Repositories
{
    public class VideojuegoRepository : IVideojuegoRepository
    {
        private readonly AppDbContext _context;

        public VideojuegoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Videojuego>> GetAllAsync()
        {
            return await _context.Videojuegos
                .Include(x => x.Categoria)
                .ToListAsync();
        }

        public async Task<Videojuego?> GetByIdAsync(int id)
        {
            return await _context.Videojuegos
                .Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Videojuego videojuego)
        {
            await _context.Videojuegos.AddAsync(videojuego);
        }

        public void Update(Videojuego videojuego)
        {
            _context.Videojuegos.Update(videojuego);
        }

        public void Delete(Videojuego videojuego)
        {
            _context.Videojuegos.Remove(videojuego);
        }

        public async Task<bool> ExistsByNameAsync(string nombre)
        {
            return await _context.Videojuegos.AnyAsync(x => x.Nombre == nombre);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}