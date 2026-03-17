using Mapster;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;
using SiemensEnergyTeste.Domain.Interfaces.Services;

namespace SiemensEnergyTeste.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task AddAsync(LivroDto livro)
        {
            var livroEntity = livro.Adapt<LivroEntity>();

            await _livroRepository.AddAsync(livroEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _livroRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LivroDto>> GetAllAsync()
        {
            var listaLivroesEntity = await _livroRepository.GetAllAsync();
            var listaLivroesViewModel = listaLivroesEntity.Adapt<List<LivroDto>>();

            return listaLivroesViewModel;
        }

        public async Task<LivroDto?> GetByIdAsync(Guid id)

        {
            var livroEntity = await _livroRepository.GetByIdAsync(id);
            var livroDto = livroEntity.Adapt<LivroDto>();

            return livroDto;
        }

        public async Task UpdateAsync(LivroDto livro)
        {
            var livroEntity = livro.Adapt<LivroEntity>();

            await _livroRepository.UpdateAsync(livroEntity);
        }
    }
}
