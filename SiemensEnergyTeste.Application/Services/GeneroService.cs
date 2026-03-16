using Mapster;
using MapsterMapper;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using SiemensEnergyTeste.Persistence.Repositories;

namespace SiemensEnergyTeste.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task AddAsync(GeneroDto genero)
        {
            var generoEntity = genero.Adapt<GeneroEntity>();

            await _generoRepository.AddAsync(generoEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _generoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GeneroDto>> GetAllAsync()
        {
            var listaGeneroesEntity = await _generoRepository.GetAllAsync();
            var listaGeneroesViewModel = listaGeneroesEntity.Adapt<IEnumerable<GeneroDto>>();

            return listaGeneroesViewModel;
        }

        public async Task<GeneroDto?> GetByIdAsync(Guid id)

        {
            var generoEntity = await _generoRepository.GetByIdAsync(id);
            var generoDto = generoEntity.Adapt<GeneroDto>();

            return generoDto;
        }

        public async Task UpdateAsync(GeneroDto genero)
        {
            var generoEntity = genero.Adapt<GeneroEntity>();

            await _generoRepository.UpdateAsync(generoEntity);
        }
    }
}
