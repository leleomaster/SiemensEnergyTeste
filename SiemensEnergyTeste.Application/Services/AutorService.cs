using MapsterMapper;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using Mapster;

namespace SiemensEnergyTeste.Application.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task AddAsync(AutorDto autor)
        {
            var autorEntity = autor.Adapt<AutorEntity>();

            await _autorRepository.AddAsync(autorEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
           await _autorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AutorDto>> GetAllAsync()
        {
            var listaAutoresEntity = await _autorRepository.GetAllAsync();
            var listaAutoresViewModel = listaAutoresEntity.Adapt<List<AutorDto>>();

            return listaAutoresViewModel;
        }

        public async Task<AutorDto?> GetByIdAsync(Guid id)

        {
            var autorEntity = await _autorRepository.GetByIdAsync(id);
            var autorDto = autorEntity.Adapt<AutorDto>();

            return autorDto;
        }

        public async Task UpdateAsync(AutorDto autor)
        {
            var autorEntity = autor.Adapt<AutorEntity>();

            await _autorRepository.UpdateAsync(autorEntity);
        }
    }
}
