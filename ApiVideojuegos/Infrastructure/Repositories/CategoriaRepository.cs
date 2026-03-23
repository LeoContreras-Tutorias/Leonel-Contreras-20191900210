using ApiVideojuegos.Data;
using ApiVideojuegos.Domain.Entities;
using ApiVideojuegos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVideojuegos.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
        }

        public async Task<bool> ExistsByNameAsync(string nombre)
        {
            return await _context.Categorias.AnyAsync(x => x.Nombre == nombre);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}