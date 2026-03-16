using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SiemensEnergyTeste.Persistence.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly SiemensEnergyTesteContext _context;

        public GeneroRepository(SiemensEnergyTesteContext context) => _context = context;

        public async Task AddAsync(GeneroEntity generoEntity)
        {
            await _context.AddAsync(generoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.FindAsync<GeneroEntity>(id);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GeneroEntity>> GetAllAsync()
        {
            return await _context.Set<GeneroEntity>().ToListAsync();
        }

        public async Task<GeneroEntity?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<GeneroEntity>(id);
        }

        public async Task UpdateAsync(GeneroEntity generoEntity)
        {
            _context.Update(generoEntity);
            await _context.SaveChangesAsync();
        }
    }
}
