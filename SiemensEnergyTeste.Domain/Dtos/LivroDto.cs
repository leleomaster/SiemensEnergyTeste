using SiemensEnergyTeste.Domain.Entities;

namespace SiemensEnergyTeste.Domain.Dtos
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public AutorEntity Autor { get; set; }
        public GeneroEntity Genero { get; set; }
    }
}
