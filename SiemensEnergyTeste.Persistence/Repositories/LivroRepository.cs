using Microsoft.EntityFrameworkCore;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;

namespace SiemensEnergyTeste.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly SiemensEnergyTesteContext _context;

        public LivroRepository(SiemensEnergyTesteContext context) => _context = context;

        public async Task AddAsync(LivroEntity livroEntity)
        {
            await _context.AddAsync(livroEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.FindAsync<LivroEntity>(id);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LivroEntity>> GetAllAsync()
        {
            return await _context.Set<LivroEntity>()
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .ToListAsync();
        }

        public async Task<LivroEntity?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<LivroEntity>(id);
        }

        public async Task UpdateAsync(LivroEntity livroEntity)
        {
            _context.Update(livroEntity);
            await _context.SaveChangesAsync();
        }
    }
}
