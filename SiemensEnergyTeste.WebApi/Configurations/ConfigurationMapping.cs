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
            #region do front para o back
            TypeAdapterConfig<LivroDto, LivroEntity>.NewConfig();
            TypeAdapterConfig<LivroDto, LivroViewModels>.NewConfig();
            TypeAdapterConfig<GeneroDto, GeneroEntity>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros);
            //.Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroEntity>>());

            TypeAdapterConfig<GeneroDto, GeneroViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros);
            //.Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());

            TypeAdapterConfig<AutorDto, AutorEntity>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros);
            //.Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroEntity>>());

            TypeAdapterConfig<AutorDto, AutorViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros);
            //.Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());

            #endregion

            #region do back para o front
            TypeAdapterConfig<LivroEntity, LivroDto>.NewConfig();
            TypeAdapterConfig<LivroViewModels, LivroDto>.NewConfig();
                        
            TypeAdapterConfig<GeneroDto, GeneroViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());

            TypeAdapterConfig<AutorEntity, AutorDto>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroDto>>()); 

            TypeAdapterConfig<AutorDto, AutorViewModels>
              .NewConfig()
              .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());

            TypeAdapterConfig<GeneroDto, GeneroViewModels>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroViewModels>>());
            TypeAdapterConfig<GeneroEntity, GeneroDto>
                .NewConfig()
                .Map(dest => dest.Livros, src => src.Livros.Adapt<ICollection<LivroDto>>());

            #endregion

            // Para usar essa configuração globalmente
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            TypeAdapterConfig.GlobalSettings.Default
               .PreserveReference(true) // Mantém a referência sem duplicar o loop
               .MaxDepth(5);
        }
    }
}
