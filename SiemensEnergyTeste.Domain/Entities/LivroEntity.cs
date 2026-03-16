using System.ComponentModel.DataAnnotations;

namespace SiemensEnergyTeste.Domain.Entities
{
    public class LivroEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Titulo { get; set; }

        public Guid AutorId { get; set; }
        public AutorEntity Autor { get; set; }

        public Guid GeneroId { get; set; }
        public GeneroEntity Genero { get; set; }
    }
}
