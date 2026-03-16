using Mapster;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Entities;
using SiemensEnergyTeste.Domain.ViewModels;
using System.Reflection;

namespace SiemensEnergyTeste.WebApi.Configurations
{
    public static class ConfigurationMapping 
    {
        public static void RegistrarMapeamento(this IServiceCollection services)
        {

            TypeAdapterConfig<LivroDto, LivroEntity>.NewConfig();
            TypeAdapterConfig<GeneroDto, GeneroEntity>
                .NewConfig()
                .Map(dest=> dest.Livros, src => src.Livros.Adapt<ICollection<LivroEntity>>());

            TypeAdapterConfig<AutorDto, AutorEntity>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroEntity>>()); ;

            TypeAdapterConfig<LivroDto, LivroViewModels>.NewConfig();
            TypeAdapterConfig<GeneroDto, GeneroViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());
            TypeAdapterConfig<AutorDto, AutorViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());

            // Para usar essa configuração globalmente
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
