using System.ComponentModel.DataAnnotations;

namespace SiemensEnergyTeste.Domain.Entities
{
    public class AutorEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Nome { get; set; }

        public ICollection<LivroEntity> Livros { get; set; }
    }
}
