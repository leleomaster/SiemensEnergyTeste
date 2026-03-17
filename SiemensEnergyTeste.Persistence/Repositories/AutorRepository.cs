using Microsoft.EntityFrameworkCore;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;

namespace SiemensEnergyTeste.Persistence.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly SiemensEnergyTesteContext _context;

        public AutorRepository(SiemensEnergyTesteContext context) => _context = context;

        public async Task AddAsync(AutorEntity autorEntity)
        {
            await _context.AddAsync(autorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.FindAsync<AutorEntity>(id);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AutorEntity>> GetAllAsync()
        {
            return await _context.Set<AutorEntity>()
                .Include(g => g.Livros)
                .ThenInclude(l => l.Genero)
                .ToListAsync();
        }

        public async Task<AutorEntity?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<AutorEntity>(id);
        }

        public async Task UpdateAsync(AutorEntity autorEntity)
        {
            _context.Update(autorEntity);
            await _context.SaveChangesAsync();
        }
    }
}
