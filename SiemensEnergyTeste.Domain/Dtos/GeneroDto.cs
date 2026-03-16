using SiemensEnergyTeste.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SiemensEnergyTeste.Domain.Dtos
{
    public class GeneroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
