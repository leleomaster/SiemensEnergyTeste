using SiemensEnergyTeste.Domain.Entities;

namespace SiemensEnergyTeste.Domain.Dtos
{
    public class AutorDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
